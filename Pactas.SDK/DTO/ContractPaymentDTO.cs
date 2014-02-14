using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pactas.SDK.DTO
{
    public class ContractPaymentDTO
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
    }
}
