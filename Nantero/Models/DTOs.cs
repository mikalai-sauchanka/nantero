
namespace Nantero.Models
{
    public class IteroJSConfigDTO
    {
        public string EntityId { get; set; }
        public string InitialPlanVariantId { get; set; }

        public string IteroBaseUrl { get; set; }

        public string ContractId { get; set; }

        public string Token { get; set; }
    }

    public class WebhookDTO
    {
        public string Event { get; set; }
        public string ContractId { get; set; }
    }

    public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string Subdomain { get; set; }
    }

    public class UpgradeDTO
    {
        public string TargetPlanVariantId { get; set; }
    }
}