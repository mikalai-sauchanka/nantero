using System;
using System.Collections.Generic;
using System.Linq;

namespace Pactas.SDK.DTO
{
    public class PaymentMethodDTO
    {
        public PaymentProvider Provider { get; set; }
        public PaymentProviderRole Role { get; set; }
    }
}
