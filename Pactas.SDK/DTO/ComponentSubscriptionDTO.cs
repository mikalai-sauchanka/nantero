using System;
using System.Collections.Generic;
using System.Linq;

namespace Pactas.SDK.DTO
{
    public class ComponentSubscriptionDTO
    {
        public DateTime? EndDate { get; set; }
        public string Memo { get; set; }
    }

    public class ComponentSubscriptionCreateDTO : ComponentSubscriptionDTO
    {
        public string ComponentId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime StartDate { get; set; }
    }

    public class ComponentSubscriptionReadDTO : ComponentSubscriptionCreateDTO
    {
        public string Id { get; set; }
        public string ContractId { get; set; }
        public string CustomerId { get; set; }
        public DateTime? BilledUntil { get; set; }
    }
}
