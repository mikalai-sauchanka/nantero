using System;
using System.Collections.Generic;
using System.Linq;

namespace Pactas.SDK.DTO
{
    public class InvoiceDraftListDTO
    {
        public string Id { get; set; }
        public string RecipientName { get; set; }
        public string RecipientSubName { get; set; }
        public DateTime Created { get; set; }
        public string Currency { get; set; }
        public decimal TotalGross { get; set; }
        public decimal TotalNet { get; set; }
        public decimal TotalVat { get; set; }

        // Not required for UI, but probably used by external API users
        public string CustomerId { get; set; }
        public string ContractId { get; set; }
        public string ExternalCustomerId { get; set; }
        public bool IsInvoice { get; set; }
    }

    public class InvoiceDraftDTO : InvoiceDraftListDTO
    {
        public AddressDTO RecipientAddress { get; set; }
        public string RecipientVatId { get; set; }
        public string Language { get; set; }

        public bool ReverseCharge { get; set; } //SimScale Hack
        public string InvoiceTemplateId { get; set; }

        public DateTime DeliveryPeriodStart { get; set; }
        public DateTime DeliveryPeriodEnd { get; set; }

        public string SequenceId { get; set; }
        public string Prologue { get; set; }
        public string Epilogue { get; set; }
        public List<LineItemDTO> ItemList { get; set; }

        public string InvoiceId { get; set; }
        public List<VatDescriptorDTO> VatDescriptors { get; set; }
    }
}
