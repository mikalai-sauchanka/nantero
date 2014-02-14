using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pactas.SDK.DTO.SelfService
{
    public class AvailablePaymentMethodsDTO
    {
        public abstract class PaymentMethodDTO
        {
        }

        public class FakePSPDTO : PaymentMethodDTO
        {
            public bool BlackLabel { get; set; }
            public bool CreditCard { get; set; }
            public bool DirectDebit { get; set; }
        }

        public class PayPalDTO : PaymentMethodDTO
        {
        }

        public class InvoicePaymentDTO : PaymentMethodDTO
        {
        }

        public class PaymillDTO : PaymentMethodDTO
        {
            public bool CreditCard { get; set; }
            public bool DirectDebit { get; set; }
            public string PublicKey { get; set; }
        }

        public class PayOneDTO : PaymentMethodDTO
        {
            public bool CreditCard { get; set; }
            public bool DirectDebit { get; set; }

            public string MerchantId { get; set; }
            public string AccountId { get; set; }
            public string PortalId { get; set; }
            public PayOneMode Mode { get; set; }
            public string BankAccountHash { get; set; }
            public string CreditCardHash { get; set; }
        }

        public class SkrillDTO : PaymentMethodDTO
        {
            public List<decimal> MaxDebitAmounts { get; set; }
            public decimal MaxDebitAmountDefault { get; set; }
        }

        public SkrillDTO Skrill { get; set; }
        public PayPalDTO PayPal { get; set; }
        public PaymillDTO Paymill { get; set; }
        public InvoicePaymentDTO InvoicePayment { get; set; }
        public FakePSPDTO FakePSP { get; set; }
        public PayOneDTO PayOne { get; set; }
    }

    public class PSPResponseDTO
    {
        public string ReponseParameters { get; set; }
    }

    public class OrderDTO
    {
        public string ContractId { get; set; }
        public CartDTO Cart { get; set; }
        public CustomerDTO Customer { get; set; }
    }

    public class OrderSelfServiceDTO
    {
        public string ContractId { get; set; }
        public CartSelfServiceDTO Cart { get; set; }
        public CustomerSelfServiceDTO Customer { get; set; }
    }

    public class OrderReadDTO : OrderDTO
    {
        public string Id { get; set; }
        public InvoiceDraftDTO InvoiceDraft { get; set; }

        public string PlanVariantId { get; set; }
        public bool AllowWithoutPaymentData { get; set; }

        /// <summary>
        /// Contains description of both the available components and the order quantities of the respective
        /// components plus the line items that explain how the current offer price was calculated
        /// </summary>
        public List<ComponentOrderSelfServiceReadDTO> ComponentSubscriptions { get; set; }

        public ComponentOrderSelfServiceReadDTO RecurringFee { get; set; }
        public ComponentOrderSelfServiceReadDTO SetupFee { get; set; }

        public string Currency { get; set; }

        public decimal Total { get; set; }
        public decimal TotalVat { get; set; }
    }

    public class OrderSelfServiceReadDTO : OrderSelfServiceDTO
    {
        public InvoiceDraftDTO InvoiceDraft { get; set; }
    }

    public enum PayOrderType
    {
        Interactive = 0,
        Synchronous = 1
    }

    public class PayOrderDTO
    {
        public PayOrderType PayOrderType { get; set; }
        public TetheredPaymentDataDTO PaymentData { get; set; }
        public string OrderId { get; set; }
    }

    public class PreviewSelfServiceDTO
    {
        public CartSelfServiceDTO Cart { get; set; }
        public CustomerSelfServiceDTO Customer { get; set; }
    }

    public class PreviewResponseSelfServiceDTO
    {
        public OrderReadDTO Order { get; set; }
    }

    public class ComponentOrderSelfServiceReadDTO : ComponentSubscriptionSelfServiceDTO
    {
        // public ComponentType ComponentType { get; set; }
        public bool PreventModification { get; set; }
        public PeriodDTO FeePeriod { get; set; }

        public string Name { get; set; }

        //#region Fake-Union
        //// Maybe use polymorphism here?
        //public PriceScale PriceScale { get; set; }
        //public DiscountScale DiscountScale { get; set; }
        public decimal? PricePerUnit { get; set; }
        //#endregion

        public IEnumerable<LineItemDTO> LineItems { get; set; }
        public decimal TotalNet { get; set; }
        public decimal TotalVat { get; set; }
    }

    /*public class CustomerDataDTO
    {
        /// <summary>
        /// A free-form string that will be assigned to the created customer's ExternalCustomerId. This can lead to trouble w/ uniqueness...
        /// </summary>
        public string ExternalCustomerId { get; set; }

        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string VatId { get; set; }
        public AddressDTO Address { get; set; }
        public string Tag { get; set; }
        public string Language { get; set; }
    }*/

    public class TetheredPaymentDataDTO
    {
        public string SelectedPaymentMethod { get; set; }
        public decimal? MaxDebitAmount { get; set; }
        public PSPBearerDTO Bearer { get; set; }
    }

    public class PaymentSuccessDTO
    {
        public string ContractId { get; set; }
        public string CustomerId { get; set; }
        public decimal Amount { get; set; }
        public string Url { get; set; }
    }

    public class PaymentResponseDTO
    {
        public CustomerSelfServiceErrorDTO Error { get; set; }
        public PaymentSuccessDTO Success { get; set; }
    }

    public class FinalizeDTO
    {
        public string ReturnUrl { get; set; }
    }

    public class SubscribePostDTO
    {
        public CartDTO Cart { get; set; }
        public CustomerDTO CustomerData { get; set; }
        public TetheredPaymentDataDTO PaymentData { get; set; }
    }


    public class CustomerSelfServiceErrorDTO
    {
        public string ErrorMessage { get; set; }
        public string UserErrorMessage { get; set; }
        public string PaymentTransactionStatus { get; set; }
        public string Details { get; set; }
    }

    public class SubscribeSuccessDTO : PaymentSuccessDTO
    {
        public string OrderId { get; set; }
    }

    public class SubscribeResponseDTO
    {
        public CustomerSelfServiceErrorDTO Error { get; set; }
        public SubscribeSuccessDTO Success { get; set; }
    }

    public class CustomerSelfServiceDTO
    {
        public string CompanyName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// The customer's preffered locale, e.g. "de-AT", "en-US", etc.
        /// </summary>
        public string Locale { get; set; }

        public string VatId { get; set; }
        public string EmailAddress { get; set; }
        public BearerMedium DefaultBearerMedium { get; set; }
        public AddressDTO Address { get; set; }
    }

    public class CustomerSelfServiceReadDTO : CustomerSelfServiceDTO
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CartDTO
    {
        public string PlanVariantId { get; set; }
        public List<ComponentSubscriptionCreateDTO> ComponentSubscriptions { get; set; }
        public List<MeteredUsageDTO> MeteredUsages { get; set; }
        public List<string> EndComponentSubscriptions { get; set; }
    }

    public class CartSelfServiceDTO
    {
        public string PlanVariantId { get; set; }
        public List<ComponentSubscriptionSelfServiceDTO> ComponentSubscriptions { get; set; }
        public List<string> EndComponentSubscriptions { get; set; }
    }

    public class ComponentSubscriptionSelfServiceDTO
    {
        public string ComponentId { get; set; }
        public decimal Quantity { get; set; }
    }

    public class ContractSelfServiceReadDTO
    {
        public ContractLifecycleStatus LifecycleStatus { get; set; }
        public decimal CurrentBalance { get; set; }
        public string Currency { get; set; }
        public DateTime Started { get; set; }
        public DateTime? NextBillingDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime BindingPeriodEnd { get; set; }

        public PaymentBearerDTO PaymentBearer { get; set; }
    }

    public class InvoiceSelfServiceReadDTO
    {
        public string InvoiceNumber { get; set; }
        public DateTime SentAt { get; set; }
        public DateTime? DueDate { get; set; }

        public decimal TotalNet { get; set; }
        public decimal TotalVat { get; set; }
        public decimal TotalGross { get; set; }

        public bool IsInvoice { get; set; }

        public decimal RemainingTotal { get; set; }//todo: Is is still needed?
    }

    public class PaymentDataSelfServiceReadDTO
    {
    }

    public class PlanSelfServiceReadDTO
    {
        public string PlanId { get; set; }
        public string PlanVariantId{ get; set; }
        public string PlanName{ get; set; }
        public PeriodDTO CancellationPeriod { get; set; }
    }

    public class ComponentSubscriptionSelfServiceReadDTO
    {
        /// <summary>
        /// TODO: We'll want to supply a simple string name since we know the destination's users
        /// preferred language anyway and we probably want to have a certain level of consistency
        /// in how the fallbacks are used, so it makes sense to keep that logic entirely on our
        /// side.
        /// </summary>
        public string ComponentName { get; set; }

        /// <summary>
        /// The external id is probably quite helpful for users because they can use that to match
        /// to their internally managed product information more easily
        /// </summary>
        public string ExternalId { get; set; }
        public string Id { get; set; }
        public string Memo { get; set; }
        public string ComponentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        // public string ContractId { get; set; }
        // public string CustomerId { get; set; }
        public DateTime? BilledUntil { get; set; }
    }

    public class PSPBearerDTO
    {
        /// <summary>
        /// Paymill, PayPal, Skrill
        /// </summary>
        public string Token { get; set; }

        #region PayOne
        public string Holder { get; set; }
        public string Country { get; set; }

        public string PseudoCardPan { get; set; }
        public string TruncatedCardPan { get; set; }
        public string CardType { get; set; }
        public int ExpiryMonth { get; private set; }
        public int ExpiryYear { get; private set; }

        public string Code { get; set; }
        public string Account { get; set; }
        public string IBAN { get; set; }
        public string BIC { get; set; }
        #endregion
    }
}
