using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using MongoDB.Driver;
using Nancy;
using Nancy.Conventions;
using Nantero.Models;
using Pactas.SDK.DTO;
using Pactas.SDK.Services;

namespace Nantero.Global
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        private static MongoContext _db;
        protected override void ConfigureConventions(NancyConventions conventions)
        {
            base.ConfigureConventions(conventions);
            // All files in the ui/ and scripts/ subfolders should be delivered as static files
            conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("ui", @"Content"));
            conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("scripts", @"scripts", ".js"));
        }

        protected override void RequestStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines, Nancy.NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);
            pipelines.OnError.AddItemToStartOfPipeline((ctx, ex) =>
            {
                return ErrorResponse.FromException(ex);
            });
        }

        protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            // Set up a connection to MongoDB
            var config = NanteroConfig.Instance;
            var connectionString = ConfigurationManager.AppSettings.Get("MONGOLAB_URI") ?? "mongodb://localhost/nantero";
            MongoUrl mongoUrl = new MongoUrl(connectionString);
            MongoClient client = new MongoClient(mongoUrl);
            var server = client.GetServer();
            _db = new MongoContext(server.GetDatabase(mongoUrl.DatabaseName));

            // Try to find the access token in the database
            var apiSettingsCollection = _db.GetCollection<ApiSettings>("ApiSettings");
            var settings = apiSettingsCollection.FindOne();

            string accessToken = null;
            if (settings != null)
                accessToken = settings.AccessToken;

            PactasApi api = new PactasApi(config.IteroBaseUrl, config.PrivateAppId, config.PrivateAppSecret, accessToken);
            api.Initialize();
            // If the API performs a token change, store the token to the DB:
            api.OnAccessTokenChanged = () => { settings.AccessToken = api.AccessToken; _db.Update(settings); };

            if (settings == null)
                apiSettingsCollection.Insert(new ApiSettings { AccessToken = api.AccessToken });

            // Get all registered webhooks from pactas itero
            var hooks = api.WebhookService.List();
            // ...and try to find a hook that targets the URL of this Nantero instance
            var existing = hooks != null ? hooks.FirstOrDefault(p => p.Url != null && p.Url.StartsWith(config.NanteroBaseUrl)) : null;
            if (existing == null)
            {
                // If no such hook is registered, register a new one for the AccountCreated event:
                api.WebhookService.Create(new Pactas.SDK.DTO.HookDTO { Url = config.NanteroBaseUrl + "hook", Events = new List<HookEvent> { HookEvent.AccountCreated } });
            }

            container.Register<MongoContext>(_db).WithStrongReference();
            container.Register<PactasApi>(api).WithStrongReference();
            
            base.ApplicationStartup(container, pipelines);
        }
    }
}

