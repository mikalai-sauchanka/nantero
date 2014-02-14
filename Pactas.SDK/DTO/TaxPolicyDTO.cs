using System.Collections.Generic;

namespace Pactas.SDK.DTO
{
    public class TaxPolicyEntryDTO
    {
        public string Country { get; set; }
        public decimal Rate { get; set; }
    }

    public class TaxPolicyDTO
    {
        public string Name { get; set; }
        public List<TaxPolicyEntryDTO> Entries { get; set; }
    }

    public class TaxPolicyReadDTO : TaxPolicyDTO
    {
        public string Id { get; set; }
    }
}
