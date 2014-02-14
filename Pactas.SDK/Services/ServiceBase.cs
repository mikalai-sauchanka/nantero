using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Pactas.SDK.Services
{
    public class ServiceBase<TRead, TWrite>
    {
        protected readonly PactasApi _api;
        private readonly string _urlFormat;

        /// <summary>
        /// A virtual getter that can be used to override the base url in descendant classes. This is used
        /// for URLs like /contracts/:contractId/usage/:id
        /// </summary>
        protected virtual string _urlFormatContext { get { return _urlFormat; } }

        public ServiceBase(PactasApi api, string urlFormat)
        {
            _api = api;
            _urlFormat = urlFormat;
        }

        protected static string FormatUrl(string result, object @params)
        {
            NameValueCollection nvc = null;
            if (@params != null)
                nvc = NameValueCollectionHelper.ExtractProperties(@params);
            if (nvc != null)
            {
                foreach (var rover in nvc.AllKeys)
                {
                    // replace :foo with a variable
                    result = result.Replace(":" + rover, nvc[rover]);
                }
            }

            result = Regex.Replace(result, ":\\w*", string.Empty); // replace any placeholders of the format :foo with empty string
            result = Regex.Replace(result, "\\/{2,}", "/"); // replace multiple forward slashes with a single slash
            // FIXME: This will kill protocol prefixes such as 'http://'!!
            return result;
        }

        private string FormattedUrl(object @params = null)
        {
            return FormatUrl(_urlFormatContext, @params);
        }

        public virtual TRead Create(TWrite item)
        {
            return _api.Post<TRead, TWrite>(FormattedUrl(), item);
        }

        public virtual IEnumerable<TRead> List(int skip = 0, int take = 50)
        {
            var result = _api.Get<IEnumerable<TRead>>(FormattedUrl(), new { skip = skip, take = take });
            return result;
        }

        public virtual string Delete(string id)
        {
            var result = _api.Delete<dynamic>(FormattedUrl(new {id = id}));
            return result;
        }

        public virtual TRead Single(string id)
        {
            var result = _api.Get<TRead>(FormattedUrl(new { id = id }));
            return result;
        }

        public virtual TRead Update(string id, TWrite item)
        {
            return _api.Put<TRead, TWrite>(FormattedUrl(new { id = id }), item);
        }

        public virtual TRead Get(object @params)
        {
            return _api.Get<TRead>(FormattedUrl(@params));
        }
    }
}
