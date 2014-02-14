using System.ComponentModel.DataAnnotations;

namespace Pactas.SDK.DTO
{
    public class CompanyInformationBaseDTO
    {
        public string CompanyName { get; set; }
    }

    public class CompanyInformationDTO : CompanyInformationBaseDTO
    {
        public TaxationBase TaxationBase { get; set; }
        public string TaxNumber { get; set; }
        public string VatId { get; set; }
        public string CityOfResidence { get; set; }
        public string RegistryCourt { get; set; }
        public string CommercialRegisterNumber { get; set; }
        public string AdministrationType { get; set; }
        public string Administration { get; set; }
        public string SupervisorBoard { get; set; }
        [DataType(DataType.MultilineText)]
        public string FurtherLegalInformation { get; set; }
        [StringLength(400)]
        public string Description { get; set; }
        [StringLength(128)]
        public string Website { get; set; }
        [StringLength(24)]
        public string PhoneNumber { get; set; }
        [StringLength(24)]
        public string FaxNumber { get; set; }
    }
}
