using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pactas.SDK.DTO
{
    public class PaymentEscalationProcessDTO
    {
        // [Required]
        public string Name { get; set; }
        public List<PaymentEscalationDescriptorDTO> Steps { get; set; }
    }

    public class PaymentEscalationProcessReadDTO : PaymentEscalationProcessDTO
    {
        public string Id { get; set; }
    }

    public class PaymentEscalationDescriptorDTO
    {
        [Range(0, 360)]
        public int TriggerDays { get; set; }
        public EscalationAction Action { get; set; }
        public string EmailId { get; set; }
    }
}
