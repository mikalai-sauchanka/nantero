using System;
using System.Collections.Generic;

namespace Pactas.SDK.DTO
{
    public class InvoiceBuilderLineItemDTO
    {
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public string TaxPolicyId { get; set; }
    }

    public class InvoiceBuilderDTO
    {
        public string Prologue { get; set; }
        public string Epilogue { get; set; }

        public DateTime? DeliveryPeriodStart { get; set; }
        public DateTime? DeliveryPeriodEnd { get; set; }

        public List<InvoiceBuilderLineItemDTO> ItemList { get; set; }
    }
}
