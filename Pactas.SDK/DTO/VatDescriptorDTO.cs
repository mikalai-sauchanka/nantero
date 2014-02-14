using System;
using System.Collections.Generic;
using System.Linq;

namespace Pactas.SDK.DTO
{
    public class VatDescriptorDTO
    {
        public decimal VatPercentage { get; set; }
        public decimal TotalNet { get; set; }
        public decimal TotalVat { get; set; }
        public decimal TotalGross { get; set; }
    }
}
