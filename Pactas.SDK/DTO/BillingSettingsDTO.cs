namespace Pactas.SDK.DTO
{
    /// <summary>
    /// </summary>
    public class BillingSettingsDTO
    {
        /// <summary>
        /// Gets or sets the billing delay.
        /// </summary>
        /// <value>
        /// Billing delay in hours.
        /// </value>
        [System.ComponentModel.DataAnnotations.Range(0, 168)]
        public int BillingDelay { get; set; }

    }
}
