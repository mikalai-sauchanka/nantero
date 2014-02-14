using System;
using System.Collections.Generic;

namespace Pactas.SDK.DTO
{
    public class PaymentTransactionStatusDTO
    {
        public PaymentStatusValue Status { get; set; }
        public DateTime Timestamp { get; set; }
        public decimal? Amount { get; set; }
    }

    public class PaymentTransactionReadDTO
    {
        public PaymentProvider PaymentProvider { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ContractId { get; set; }
        public string Contract { get; set; }

        public string ProviderPaymentToken { get; set; }
        public string ProviderTransactionId { get; set; }

        public List<PaymentTransactionStatusDTO> StatusHistory { get; set; }
        public PaymentTransactionStatusDTO Status { get; set; }

        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public DateTime StatusTimestamp { get; set; }
    }


}
