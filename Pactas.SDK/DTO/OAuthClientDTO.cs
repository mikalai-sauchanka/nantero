using System;

namespace Pactas.SDK.DTO
{
    public enum OAuthClientType
    {
        /// <summary>
        /// Public clients are unable to keep a client_password safe (e.g. javascript applications,
        /// mobile applications, desktop applications).
        /// </summary>
        Public = 0,
        /// <summary>
        /// Confidential applications can keep a secret (e.g. server applications where only the 
        /// administrator has access to the binaries / sources).
        /// </summary>
        Confidential = 1,
    }

    public class OAuthGrantReadDTO
    {
        public string ClientId { get; set; }
        public string UserId { get; set; }
        public DateTime? ExpiryUTC { get; set; }
        public string Scopes { get; set; }
        public string TokenType { get; set; }
        public string ClientName { get; set; }
    }

    public class OAuthClientDTO
    {
        public string Name { get; set; }
        public string Callback { get; set; }
        public OAuthClientType ClientType { get; set; }
    }

    public class OAuthClientReadDTO : OAuthClientDTO
    {
        public string Secret { get; set; }
        public string Id { get; set; }
    }
}
