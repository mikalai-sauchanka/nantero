
using System.Collections.Generic;
namespace Pactas.SDK.DTO
{
    public class SelfServiceSettingsDTO
    {
        public string CustomCss { get; set; }
        public string ErrorUrl { get; set; }
        public string SuccessUrl { get; set; }
        public string ProviderReturnUrl { get; set; }
        public string AuthSecret { get; set; }
        public List<AvailablePaymentMethodDTO> AvailablePaymentMethods { get; set; }
        public string PaymentMethodDefault { get; set; }
        public LocalizableString PreauthText { get; set; }
    }
}
