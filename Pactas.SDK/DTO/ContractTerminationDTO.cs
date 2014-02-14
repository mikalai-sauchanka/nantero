using System;
using System.Collections.Generic;
using System.Linq;

namespace Pactas.SDK.DTO
{
    public class ContractTerminationDTO
    {
        public DateTime EndDate { get; set; }
        public DateTime MaxBilledUntil { get; set; }
        public decimal ToBill { get; set; }
    }
}
