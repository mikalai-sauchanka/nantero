using System;
using System.Collections.Generic;
using System.Linq;

namespace Pactas.SDK.DTO
{
    public class ProductInfoDTO
    {
        public List<PlanGroupReadDTO> PlanGroups { get; set; }
        public List<PlanReadDTO> Plans { get; set; }
        public List<PlanVariantReadDTO> PlanVariants { get; set; }
        public List<ComponentReadDTO> Components { get; set; }
        public List<TaxPolicyReadDTO> TaxPolicies { get; set; }
    }
}
