
namespace Pactas.SDK.DTO
{
    public class PaymentProviderStatusDTO
    {
        public bool BlackLabelActive { get; set; }
        public bool CreditCardActive { get; set; }
        public bool DebitActive { get; set; }
    }

    public class PaymentProviderSettingsDTO
    {
        public PaymentProvider PaymentProvider { get; set; }
    }

    public class PaymentProviderSettingsReadDTO : PaymentProviderSettingsDTO
    {
        public PaymentProviderSettingsReadDTO()
        {
            Status = new PaymentProviderStatusDTO();
        }

        public bool Blocked { get; set; }
        public PSPAccountWarning? Warning { get; set; }
        public bool Valid { get; set; }
        public PaymentProviderStatusDTO Status { get; set; }
        public bool IsCreditCardProvider { get; set; }
        public bool IsDebitProvider { get; set; }
        public bool IsBlackLabelProvider { get; set; }
    }

    public class DTAUSSettingsDTO : PaymentProviderSettingsDTO
    {
        public string AccountOwnersName { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingCode { get; set; }
    }

    public class DTAUSSettingsReadDTO : PaymentProviderSettingsReadDTO
    {
        public string AccountOwnersName { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingCode { get; set; }
    }

    public class FakeProviderSettingsDTO : PaymentProviderSettingsDTO
    {
        public bool Configured { get; set; }
    }

    public class FakeProviderSettingsReadDTO : PaymentProviderSettingsReadDTO
    {
        public bool Configured { get; set; }
    }

    public class PaymillSettingsDTO : PaymentProviderSettingsDTO
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public string WebhookId { get; set; }
        public string MerchantId { get; set; }
    }

    public class PaymillSettingsReadDTO : PaymentProviderSettingsReadDTO
    {
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public string WebhookId { get; set; }
        public string MerchantId { get; set; }
    }

    public class PayOneSettingsDTO : PaymentProviderSettingsDTO
    {
        public PayOneMode Mode { get; set; }
        public string MerchantId { get; set; }
        public string AccountId { get; set; }
        public string PortalId { get; set; }
        public string Key { get; set; }
        public string CreditCardCheckHash { get; set;}
        public string BankAccountCheckHash { get; set; }
        public string PortalIdRecurring { get; set; }
        public string KeyRecurring { get; set; }
    }

    public class PayOneSettingsReadDTO : PaymentProviderSettingsReadDTO
    {
        public PayOneMode Mode { get; set; }
        public string MerchantId { get; set; }
        public string AccountId { get; set; }
        public string PortalId { get; set; }
        public string Key { get; set; }
        public string CreditCardCheckHash { get; set; }
        public string BankAccountCheckHash { get; set; }
        public string PortalIdRecurring { get; set; }
        public string KeyRecurring { get; set; }
        public string WebhookUrl { get; set; }
    }

    public class PayPalSettingsDTO : PaymentProviderSettingsDTO
    {
        public PayPalEnvironment Environment { get; set; }
        public string APIUsername { get; set; }
        public string APIPassword { get; set; }
        public string APISignature { get; set; }
        public string AppId { get; set; }
        public string Email { get; set; }
        public PayPalApiType PayPalApiType { get; set; }
        public PayPalAPMode APMode { get; set; }
    }

    public class PayPalSettingsReadDTO : PaymentProviderSettingsReadDTO
    {
        public PayPalEnvironment Environment { get; set; }
        public string APIUsername { get; set; }
        public string APIPassword { get; set; }
        public string APISignature { get; set; }
        public string AppId { get; set; }
        public string Email { get; set; }
        public PayPalApiType PayPalApiType { get; set; }
        public PayPalAPMode APMode { get; set; }
    }

    public class SkrillSettingsDTO : PaymentProviderSettingsDTO
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string MerchantId { get; set; }
        public string SecretWord { get; set; }
        public bool AccountChecked { get; set; }
        public decimal[] MaxDebitAmounts { get; set; }
        public decimal? MaxDebitAmountDefault { get; set; }
    }

    public class SkrillSettingsReadDTO : PaymentProviderSettingsReadDTO
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string MerchantId { get; set; }
        public string SecretWord { get; set; }
        public bool AccountChecked { get; set; }
        public decimal[] MaxDebitAmounts { get; set; }
        public decimal? MaxDebitAmountDefault { get; set; }
    }

    public class InvoicePaymentSettingsDTO : PaymentProviderSettingsDTO
    {
        public PeriodDTO DueAfter { get; set; }
    }

    public class InvoicePaymentSettingsReadDTO : PaymentProviderSettingsReadDTO
    {
        public PeriodDTO DueAfter { get; set; }
    }
}
