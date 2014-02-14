
namespace Pactas.SDK.DTO
{
    public class ContractActivationDTO
    {
        public PaymentMethodDTO PaymentMethod { get; set; }
        public string RedirectUrl { get; set; }
    }

    public class ContractActivationFinishDTO
    {
        public string CustomerId { get; set; }
        public string ContractId { get; set; }
        public bool Succeeded { get; set; }
        public string Secret { get; set; }
    }

    public class ContinuePaymentsDTO
    {
        public bool Succeeded { get; set; }
    }
}
