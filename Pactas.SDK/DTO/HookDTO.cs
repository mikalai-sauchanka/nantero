using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pactas.SDK.DTO
{
    public enum HookEvent
    {
        AccountCreated = 0,
        // AccountCancelled = 1,
        // TrialExpired = 2,
        PaymentSucceeded = 3,
        PaymentFailed = 4,
        // Chargeback = 5,
        ContractChanged = 6,
        DebitAuthCancelled = 7,

        /// <summary>
        /// Indicates that the customer's data has changed
        /// </summary>
        CustomerChanged = 8,
        PaymentEscalated = 9,
        PaymentBearerExpiring = 10
    }

    public class HookDTOValidator
    {
        public static ValidationResult ValidateHookDTO(HookDTO dto)
        {
            if(!Uri.IsWellFormedUriString(dto.Url, UriKind.Absolute))
                return new ValidationResult(string.Format("'{0}' is not a valid absolute URI", dto.Url), new List<string> { "Url" });
            if(dto.Events == null || dto.Events.Count == 0)
                return new ValidationResult(string.Format("Events must not be empty"), new List<string> { "Events" });

            return ValidationResult.Success;
        }
    }


    [CustomValidation(typeof(HookDTOValidator), "ValidateHookDTO")]
    public class HookDTO
    {
        [Required]
        public string Url { get; set; }

        [Required]
        public List<HookEvent> Events { get; set; }
    }

    public class HookReadDTO : HookDTO
    {
        public string Id { get; set; }
    }
}
