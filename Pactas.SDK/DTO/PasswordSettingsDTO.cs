using System;
using System.Collections.Generic;
using System.Linq;

namespace Pactas.SDK.DTO
{
    public class PasswordSettingsDTO
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmationPassword { get; set; }
    }
}
