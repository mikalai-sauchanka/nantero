using System;

namespace Pactas.SDK.DTO
{
    public class LedgerEntryReadDTO
    {
        public LedgerEntryType Type { get; set; }
        public string ContractId { get; set; }
        public string CustomerId { get; set; }

        public string Description { get; set; }

        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }

        public string Country { get; set; }
        public decimal VatPercentage { get; set; }

        public LedgerAmountType AmountType { get; set; }

        // Payment Transaction properties
        public string PaymentTransactionId { get; set; }
        public PaymentStatusValue? PaymentTransactionStatus { get; set; }

        // Adjustement entry properties
        public string AdjustmentUserId { get; set; }

        // Claim properties
        public string InvoiceId { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
