using System;
using System.Collections.Generic;
using System.Linq;

namespace Pactas.SDK.DTO
{
    public class AccountSettingsDTO
    {
        public UserInformationDTO UserInfo { get; set; }
        public CompanyInformationDTO CompanyInfo { get; set; }
        public AddressDTO InvoiceAddress { get; set; }
    }
}
