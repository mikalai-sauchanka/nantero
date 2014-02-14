using System;

namespace Pactas.SDK.DTO
{
    public class LineItemDTO
    {
        /// <summary>
        /// The invoice sender's product number for that item
        /// </summary>
        public string ProductNumber { get; set; }

        /// <summary>
        /// A description which might be quite long and should at least support full plain-text formatting 
        /// (including line breaks). Maybe markdown?
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The amount of items
        /// </summary>
        public decimal Quantity { get; set; }

        /// <summary>
        /// The net price, taking allowances into account (compatible to UBL)
        /// </summary>
        public decimal PricePerUnit { get; set; }

        /// <summary>
        /// The amount of VAT, in percent
        /// </summary>
        public decimal VatPercentage { get; set; }

        public DateTime? PeriodStart { get; set; }

        public DateTime? PeriodEnd { get; set; }

        public decimal? PeriodMultiplier { get; set; }

        public decimal? ScaleAmount { get; set; }

        public string Unit { get; set; }

        /// <summary>
        /// PlanVariantId or ComponentId
        /// </summary>
        public string ProductId { get; set; }

        public decimal TotalNet { get; set; }

        public decimal TotalVat { get; set; }

        public decimal TotalGross { get; set; }
    }
}
