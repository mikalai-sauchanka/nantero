using System;

namespace Pactas.SDK.DTO
{
    public class SelfServiceTokenDTO
    {
        public DateTime Expiry { get; set; }
        public string Token { get; set; }
        public string Purpose { get; set; }
        public string Url { get; set; }
    }
}
