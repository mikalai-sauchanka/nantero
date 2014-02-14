using System;
using System.Collections.Generic;
using System.Linq;

namespace Pactas.SDK.DTO
{
    public enum TrialEndPolicy
    {
        NoTrial = 0,
        /// <summary>
        /// Deactivates the account using a webhook
        /// </summary>
        DeactivateAccount = 1,
        /// <summary>
        /// Initiates a payment and prolongs the contract
        /// </summary>
        RequestPayment = 2,
    }

    public class PlanDTO
    {
        public LocalizableString Name { get; set; }
        public LocalizableString SetupDescription { get; set; }
        public PeriodDTO TrialPeriod { get; set; }
        public TrialEndPolicy TrialEndPolicy { get; set; }
    }

    public class PlanReadDTO : PlanDTO
    {
        public string PlanGroupId { get; set; }
        public string Id { get; set; }
    }
}
