using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Cstieg.Sales.PayPal.Models
{
    /// <summary>
    /// Model of an Amount of payment made through PayPal Payments API.
    /// Child of Transaction
    /// </summary>
    [DataContract]
    public class Amount : IPayPalEntity
    {
        /// <summary>
        /// The three-character ISO-4217 currency code.  PayPal does not support all currencies.
        /// </summary>
        [Required]
        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The total amount charged to the payee by the payer.  For refunds, represents the amount that the payer refunds to the original payer.
        /// Maximum length is 10 characters, including 2 digits after the decimal point.
        /// </summary>
        [Required]
        [DataMember(Name = "total")]
        public decimal Total { get; set; }

        /// <summary>
        /// The additional details about the payment amount.
        /// </summary>
        [DataMember(Name = "details")]
        public AmountDetails AmountDetails { get; set; }
    }
}
