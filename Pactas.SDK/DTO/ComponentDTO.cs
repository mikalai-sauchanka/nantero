using System;
using System.Collections.Generic;

namespace Pactas.SDK.DTO
{
    public enum ProductTypeFilter
    {
        All = 0,
        OnlyTimeBased = 1,
        OnlyQuantityBased = 2
    }

    public class ComponentDTO
    {
        public bool AllowSelfService { get; set; }
        public ComponentTypeDTO ComponentType { get; set; }
        public PeriodDTO FeePeriod { get; set; }
        public bool Prorate { get; set; }
        public PaymentPeriodMode PaymentPeriodMode { get; set; }
        public LocalizableString Name { get; set; }
        public string Unit { get; set; }
        public string TaxPolicyId { get; set; }

        public string ExternalId { get; set; }

        public PriceScaleDTO PriceScale { get; set; }
        public DiscountScaleDTO DiscountScale { get; set; }
        public decimal? PricePerUnit { get; set; }
    }

    public class ComponentReadDTO : ComponentDTO
    {
        public string Id { get; set; }
        public string PlanGroupId { get; set; }
    }
}
