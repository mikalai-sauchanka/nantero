using System;
using CodeContract = System.Diagnostics.Contracts.Contract;

namespace Pactas.SDK.Services
{
    internal class TokenResponseDTO
    {
        public string access_token { get; set; }
    }

    public class PactasApi
    {
        private readonly string _apiUrl;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private string _accessToken;

        private readonly RestClient _rc;

        private CustomerService _customerService;
        private ContractService _contractService;
        private WebhookService _webhookService;
        private OrderService _orderService;

        public PactasApi(string url, string clientId, string clientSecret, string accessToken = null)
        {
            CodeContract.Requires<ArgumentException>(string.IsNullOrWhiteSpace(url) == false);
            CodeContract.Requires<ArgumentException>(string.IsNullOrWhiteSpace(clientId) == false);
            CodeContract.Requires<ArgumentException>(string.IsNullOrWhiteSpace(clientSecret) == false);
            _apiUrl = url;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _accessToken = accessToken;
            _rc = new RestClient(_apiUrl);
        }

        public Action OnAccessTokenChanged { get; set; }

        public string AccessToken { get { return _accessToken; } }

        public CustomerService CustomerService
        {
            get
            {
                if (_customerService == null)
                    _customerService = new CustomerService(this);
                return _customerService;
            }
        }

        public ContractService ContractService
        {
            get
            {
                if (_contractService == null)
                    _contractService = new ContractService(this);
                return _contractService;
            }
        }

        public OrderService OrderService
        {
            get
            {
                if (_orderService == null)
                    _orderService = new OrderService(this);
                return _orderService;
            }
        }

        public WebhookService WebhookService
        {
            get
            {
                if (_webhookService == null)
                    _webhookService = new WebhookService(this);
                return _webhookService;
            }
        }

        public void Initialize()
        {
            if (string.IsNullOrWhiteSpace(_accessToken))
                _accessToken = RetrieveAccessToken();

            _rc.AddDefaultParameter("Authorization", "Bearer " + _accessToken);
        }

        /// <summary>
        /// Retrieves an access token using the client_credentials grant. This method can be used to verify
        /// the given credentials
        /// </summary>
        /// <returns></returns>
        public string RetrieveAccessToken()
        {
            RestClient rc = new RestClient(_apiUrl);
            var request = new RestRequest(Method.POST, "/oauth/token") { Body = "grant_type=client_credentials", ContentType = "application/x-www-form-urlencoded" };
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(string.Format("{0}:{1}", _clientId, _clientSecret))));
            var response = rc.Execute(request);
            var tokenResponse = response.ResponseAs<TokenResponseDTO>();
            if (tokenResponse != null)
                return tokenResponse.access_token;
            else
                throw new RestException("Failed to retrieve access token!");
        }

        public RestClient RestClient { get { return _rc; } }

        private T SendRequest<T>(RestRequest request)
        {
            if (request.AttemptCount > 1)
                throw new RestException("Unauthorized. Failed to resolve authorization issue after re-acquiring access token.");

            var response = _rc.Execute(request);
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    return response.ResponseAs<T>();
                case System.Net.HttpStatusCode.NoContent:
                case System.Net.HttpStatusCode.NotModified:
                    return default(T);
                case System.Net.HttpStatusCode.Unauthorized:
                    _accessToken = RetrieveAccessToken();
                    if(OnAccessTokenChanged != null)
                        OnAccessTokenChanged();
                    _rc.AddDefaultParameter("Authorization", "Bearer " + _accessToken, true);
                    return SendRequest<T>(request);
                default:
                    throw new RestException(response);
            }
        }

        internal T Post<T, T1>(string url, T1 body)
        {
            return SendRequest<T>(new RestRequest(Method.POST, url)
            {
                Body = ServiceStack.Text.JsonSerializer.SerializeToString(body)
            });
        }

        internal T Put<T, T1>(string url, T1 body)
        {
            return SendRequest<T>(new RestRequest(Method.PUT, url)
            {
                Body = ServiceStack.Text.JsonSerializer.SerializeToString(body)
            });
        }

        internal T Get<T>(string url, object parameters = null)
        {
            return SendRequest<T>(new RestRequest(Method.GET, url, parameters));
        }

        internal T Delete<T>(string url, object parameters = null)
        {
            return SendRequest<T>(new RestRequest(Method.DELETE, url, parameters));
        }
    }
}
