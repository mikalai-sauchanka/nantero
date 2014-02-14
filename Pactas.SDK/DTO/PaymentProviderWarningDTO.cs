using System;
using System.Collections.Generic;
using System.Linq;

namespace Pactas.SDK.DTO
{
    public class PaymentProviderWarningDTO
    {
        public PaymentProvider PaymentProvider { get; set; }
        public PSPAccountWarning Warning { get; set; }
    }
}
