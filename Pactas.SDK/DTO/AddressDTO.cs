using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pactas.SDK.DTO
{
    public class AddressValidation
    {
        public static ValidationResult ValidateCountry(string country)
        {
            if (!string.IsNullOrEmpty(country) && !Enum.IsDefined(typeof(Iso3166Country), country))
                return new ValidationResult(string.Format("'{0}' is not a valid ISO 3166 country code", country), new List<string> { "Country" });
            return ValidationResult.Success;
        }
    }

    public class AddressDTO
    {
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        /// <summary>
        /// The 2-letter ISO country code in capital letters, e.g. DE
        /// </summary>
        [StringLength(2, MinimumLength = 2)]
        [Required]
        [CustomValidation(typeof(AddressValidation), "ValidateCountry")]
        public string Country { get; set; }
    }
}
