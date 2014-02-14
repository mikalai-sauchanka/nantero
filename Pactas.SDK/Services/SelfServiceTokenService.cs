using Pactas.SDK.DTO;

namespace Pactas.SDK.Services
{
    public class SelfServiceTokenWriteDTO { };

    public class SelfServiceTokenService: ServiceBase<SelfServiceTokenDTO, SelfServiceTokenWriteDTO>
    {
        public SelfServiceTokenService(PactasApi api)
            : base(api, "contracts/:contractId/selfServiceToken")
        {
        }

        public string RetrieveSelfServiceTokenForContract(string contractId)
        {
            var result = base.Get(new { contractId = contractId });
            return result.Token;
        }
    }
}
