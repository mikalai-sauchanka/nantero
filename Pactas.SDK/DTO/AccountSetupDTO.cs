using System;
using System.Collections.Generic;
using System.Linq;

namespace Pactas.SDK.DTO
{
    public class AccountSetupDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string CompanyName { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string EmailAddress { get; set; }
    }
}
