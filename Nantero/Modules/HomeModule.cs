using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using Nancy;
using Nancy.ModelBinding;
using Nantero.Global;
using Nantero.Models;
using Pactas.SDK.DTO.SelfService;
using Pactas.SDK.Services;

namespace Nantero.Modules
{
    public class HomeModule : Nancy.NancyModule
    {
        private readonly MongoContext _db;

        public HomeModule(MongoContext db, PactasApi api)
        {
            _db = db;

            var userCollection = _db.GetCollection<User>("User");
            var config = NanteroConfig.Instance;

            // For the account settings, we're just using some user. A real implementation would have to have authentication
            // and select the user that is currently logged-in, of course
            var someUser = userCollection.Find(Query<User>.NE(p => p.PactasContractId, null)).FirstOrDefault();

            Get["/"] = _ => Response.AsRedirect("/ui/signup.html");
            Get["/account"] = _ => Response.AsRedirect("/ui/account.html");

            // register a new user in the nantero database
            Post["/register"] = _ =>
            {
                var registerDto = this.Bind<RegisterDTO>();
                // In a real application, you'll want to have the user expire if the signup 
                // confirmation doesn't arrive within, say, a few days. Also, you'd want to
                // make sure that the subdomain is unique.
                var user = new User { Subdomain = registerDto.Subdomain };
                userCollection.Insert(user);
                return Response.AsJson(user);
            };

            // This receives webhooks from pactas
            Post["/hook"] = _ =>
            {
                // Read the received webhook
                var hook = this.Bind<WebhookDTO>();
                // Fetch the contract from pactas
                var contract = api.ContractService.Single(hook.ContractId);
                // .. and the customer
                var customer = api.CustomerService.Single(contract.CustomerId.ToString());

                // Store the contract id and update the "IsActive" flag so we know the user has paid for the account
                var updated = userCollection.Update(Query<User>.EQ(p => p.Id, ObjectId.Parse(customer.Tag)), 
                    Update<User>.Set(p => p.IsActive, true).Set(p => p.PactasContractId, hook.ContractId));

                if (updated.DocumentsAffected != 1)
                    return Response.AsJson(new { Message = "Error: user not found" }, HttpStatusCode.NotFound);
                else
                    return Response.AsJson(new { Message = "THXNBYE"} );
            };


            Get["/config"] = _ =>
            {
                SelfServiceTokenService ssts = new SelfServiceTokenService(api);
                string contractId = someUser != null ? someUser.PactasContractId : "";

                string token = string.Empty;
                if (!string.IsNullOrEmpty(contractId))
                    token = ssts.RetrieveSelfServiceTokenForContract(contractId);

                // Return the public configuration settings for the JS frontend. You could also 
                // hardcode this in the frontend, but this way, all configuration is in a single place
                return Response.AsJson(new IteroJSConfigDTO
                {
                    InitialPlanVariantId = config.PlanVariantId,
                    EntityId = config.EntityId,
                    IteroBaseUrl = config.IteroBaseUrl,
                    ContractId = contractId,
                    Token = token
                });
            };

            Post["/upgrade"] = _ =>
            {
                // Read the id of the plan variant that the user wants to up/downgrade to:
                var dto = this.Bind<UpgradeDTO>();
                string newPlanVariantId = dto.TargetPlanVariantId;

                // HACK: We're using a random user's contract here. A real implementation would 
                // of course feature authentication and know who is currently logged in.
                string contractId = someUser.PactasContractId;

                // Create an upgrade order
                OrderDTO order = new OrderDTO
                {
                    ContractId = contractId,
                    Cart = new CartDTO
                    {
                        PlanVariantId = newPlanVariantId
                    },
                    Customer = null
                };

                var orderResult = api.OrderService.Create(order);
                return Response.AsJson(orderResult);
            };
        }
    }
}
