using System;
using System.Collections.Generic;

namespace Pactas.SDK.DTO
{
    /// <summary>
    /// Defines which placesholders are available
    /// </summary>
    public enum EmailType
    {
        /// <summary>
        /// tell a customer that a payment was successful
        /// </summary>
        PaymentSucceeded = 0,

        /// <summary>
        /// tell a customer that a payment has failed
        /// </summary>
        PaymentFailed = 1,

        /// <summary>
        /// tell the customer that his payment information is no longer valid, e.g. because of an expiring credit card
        /// </summary>
        PaymentInfoExpired = 2,

        /// <summary>
        /// tells the customer that his account is now terminated
        /// </summary>
        AccountDeactivated = 3,

        /// <summary>
        /// This is to announce that payment information has changed, which is basically a security feature
        /// </summary>
        PaymentInfoChanged = 10,

        /// <summary>
        /// An invoice email
        /// </summary>
        Invoice = 20,

        /// <summary>
        /// A dunning email
        /// </summary>
        Dunning = 21,

        /// <summary>
        /// A creditnote email
        /// </summary>
        CreditNote = 22,
    }

    public class EmailTemplateDTO
    {
        public LocalizableString Subject { get; set; }
        public LocalizableString HtmlText { get; set; }
        public EmailType EmailType { get; set; }

        public string SenderName { get; set; }
        public string ReplyToAddress { get; set; }
        public string BccAddress { get; set; }
    }

    /// <summary>
    /// TODO: maybe put the placeholders in this DTO? 
    /// </summary>
    public class EmailTemplateReadDTO : EmailTemplateDTO
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }

        public List<string> Placeholders { get; set; }
    }

}
