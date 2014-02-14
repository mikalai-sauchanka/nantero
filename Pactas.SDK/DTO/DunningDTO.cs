using System;
using System.Collections.Generic;

namespace Pactas.SDK.DTO
{
    public class DunningListDTO
    {
        public string Id { get; set; }
        public string DunningNumber { get; set; }

        public DateTime? SentAt { get; set; }
        public DateTime CreationTime { get; set; }

        public string CustomerId { get; set; }
        public string ContractId { get; set; }

        public string RecipientName { get; set; }
        public string RecipientSubName { get; set; }
        public AddressDTO RecipientAddress { get; set; }

        public string Currency { get; set; }

        public decimal Total { get; set; }
    }

    public class DunningDetailDTO : DunningListDTO
    {
        public string SenderName { get; set; }
        public AddressDTO SenderAddress { get; set; }

        public string SenderVatId { get; set; }
        public string SenderTaxNumber { get; set; }
        public string RecipientVatId { get; set; }
        public string RecipientTaxNumber { get; set; }

        public List<DunningItemDTO> Items { get; set; }
        public string Prologue { get; set; }
        public string Epilogue { get; set; }

        public BearerMedium BearerMedium { get; set; }
    }

    public class DunningItemDTO
    {
        public string InvoiceId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Total { get; set; }
        public decimal Remaining { get; set; }
    }

}
