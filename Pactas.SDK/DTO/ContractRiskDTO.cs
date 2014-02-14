namespace Pactas.SDK.DTO
{
    public class ContractRiskDTO
    {
        public decimal UnbilledMetered { get; set; }
        public decimal LedgerBalance { get; set; }
        public decimal Total { get; set; }
        public string Currency { get; set; }
    }
}