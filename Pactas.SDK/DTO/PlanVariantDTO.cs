using System;
using System.Collections.Generic;
using System.Linq;

namespace Pactas.SDK.DTO
{
    public class PlanVariantDTO
    {
        public bool AllowSelfService { get; set; }
        public bool AllowWithoutPaymentData { get; set; }
        public PeriodDTO ContractPeriod { get; set; }
        public PeriodDTO LaterContractPeriod { get; set; }
        public PeriodDTO CancellationPeriod { get; set; }
        public PeriodDTO LaterCancellationPeriod { get; set; }
        public PeriodDTO BillingPeriod { get; set; }
        public PeriodDTO FeePeriod { get; set; }

        public PaymentPeriodMode PaymentPeriodMode { get; set; }

        public List<FreeQuotaDescriptorDTO> Quota { get; set; }

        public decimal RecurringFee { get; set; }
        public decimal? SetupFee { get; set; }
    }

    public class PlanVariantReadDTO : PlanVariantDTO
    {
        public string Id { get; set; }
        public string PlanId { get; set; }
    }
}
