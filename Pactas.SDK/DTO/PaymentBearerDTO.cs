using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pactas.SDK.DTO
{
    public abstract class PaymentBearerDTO
    {
        public abstract string Type { get; }
    }

    public class PaymentBearerCreditCardDTO : PaymentBearerDTO
    {
        /// <summary>
        /// Visa, Mastercard, ...
        /// </summary>
        public string CardType { get; set; }

        /// <summary>
        /// Expiry month of the credit card
        /// </summary>
        public int ExpiryMonth { get; set; }

        /// <summary>
        /// Expiry year of the credit card
        /// </summary>
        public int ExpiryYear { get; set; }

        /// <summary>
        /// Name of the card holder
        /// </summary>
        public string Holder { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// The last four digits of the credit card
        /// </summary>
        public string Last4 { get; set; }

        public override string Type { get { return "CreditCard"; } }
    }

    public class PaymentBearerBankAccountDTO : PaymentBearerDTO
    {
        /// <summary>
        /// The used Bank Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Name of the account holder
        /// </summary>
        public string Holder { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// The used account number, for security reasons the number is masked
        /// </summary>
        public string Account { get; set; }

        public string IBAN { get; set; }
        public string BIC { get; set; }

        public override string Type { get { return "BankAccount"; } }
    }
}
