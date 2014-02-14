using System;

namespace Pactas.SDK.DTO
{
    public class CalcBilledUntilDTO
    {
        public DateTime StartDate { get; set; }
        public int BilledPeriods { get; set; }
        public string CustomerId { get; set; }
        public DateTime BilledUntil { get; set; }
    }
}
