using System.Collections.Generic;

namespace Pactas.SDK.DTO
{
    public class InvoicePreviewDTO
    {
        public string Currency { get; set; }
        public decimal TotalGross { get; set; }
        public decimal TotalNet { get; set; }
        public decimal TotalVat { get; set; }
        
        public bool ReverseCharge { get; set; }

        #region TODO: Test if these fields will be set!
        public string RecipientName { get; set; }
        public string RecipientSubName { get; set; }
        public AddressDTO RecipientAddress { get; set; }
        public string CustomerId { get; set; }
        public string ContractId { get; set; }
        public string ExternalCustomerId { get; set; }
        #endregion

        public List<LineItemDTO> ItemList { get; set; }
        public List<VatDescriptorDTO> VatDescriptors { get; set; }
    }
}