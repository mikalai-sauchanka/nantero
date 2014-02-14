using System;
using System.Collections.Generic;
using System.Linq;

namespace Pactas.SDK.DTO
{
    public class SignupDTO
    {
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public bool AcceptTermsOfUse { get; set; }
    }
}
