using System;
using System.Collections.Generic;
using System.Linq;

namespace Pactas.SDK.DTO
{
    public class PlanGroupDTO
    {
        public LocalizableString Name { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public string TaxPolicyId { get; set; }
        public SelfServicePlanGroupSettingsDTO SelfServiceSettings { get; set; }
    }

    public class SelfServicePlanGroupSettingsDTO
    {
        public bool ShowVatId { get; set; }
        public bool ShowCompanyName { get; set; }
        public bool ShowEmailAddress { get; set; }
        public bool ShowBillingAddress { get; set; }
    }

    public class PlanGroupReadDTO : PlanGroupDTO
    {
        public string Id { get; set; }
    }
}
