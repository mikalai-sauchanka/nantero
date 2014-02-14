namespace Pactas.SDK.DTO
{
    public class UserInformationBaseDTO
    {
        public Salutation Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }

    public class UserInformationDTO : UserInformationBaseDTO
    {
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string PhoneNumber { get; set; }
    }
}
