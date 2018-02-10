using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

/// <summary>
/// Classes modeling json objects used to make PayPal API calls, and received in response from PayPal API calls
/// </summary>
namespace Cstieg.Sales.PayPal.Models
{
    /// <summary>
    /// Top-level Json object containing information on a payment through PayPal Payments API.
    /// </summary>
    [DataContract]
    public class PaymentDetails : IPayPalEntity
    {
        /// <summary>
        /// The payment intent.  Allowed values: 
        ///   "sale" makes an immediate payment
        ///   "authorize" authorizes a payment for capture later
        ///   "order" creates an order
        /// </summary>
        [Required]
        [DataMember(Name = "intent")]
        public string Intent { get; set; }

        /// <summary>
        /// The source of the funds for this payment.  
        /// Payment method is PayPal Wallet payment or bank direct debit.
        /// </summary>
        [Required]
        [DataMember(Name = "payer")]
        public Payer Payer { get; set; }

        /// <summary>
        /// An array of payment-related transactions.  A transaction defines what the payment is for and who fulfills the payment.
        /// For update and execute payment calls, the transactions object accepts the amount object only.
        /// </summary>
        [Required]
        [DataMember(Name = "transactions")]
        public IEnumerable<Transaction> Transactions { get; set; }

        /// <summary>
        /// The PayPal-generated ID for the merchant's payment experience profile.
        /// </summary>
        [DataMember(Name = "experience_profile_id")]
        public string ExperienceProfileId { get; set; }

        /// <summary>
        /// A free-form field that clients can use to send a note to the payer.
        /// </summary>
        [DataMember(Name = "note_to_payer")]
        [StringLength(165)]
        public string NoteToPayer { get; set; }

        /// <summary>
        /// A set of redirect URLs that you provide for PayPal-based payments.
        /// </summary>
        [DataMember(Name = "redirect_urls")]
        public RedirectUrls RedirectUrls { get; set; }
    }

}
