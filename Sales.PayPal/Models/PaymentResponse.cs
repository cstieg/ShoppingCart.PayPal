using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Cstieg.Sales.PayPal.Models
{
    /// <summary>
    /// Model of a response received from PayPal Payments API after posting a payment.  
    /// Contains info necessary to execute and finalize the payment.
    /// </summary>
    [DataContract]
    public class PaymentResponse : IPayPalEntity
    {
        /// <summary>
        /// The ID of the payment
        /// </summary>
        [Required]
        [DataMember(Name = "id")]
        public string Id { get; set; }

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
        /// The state of the payment, authorization, or order transaction. Value is:
        ///   "created" - the transaction was successfully created.
        ///   "approved" - the buyer approved the transaction.
        ///   "failed" - the transaction request failed.
        /// </summary>
        [DataMember(Name = "state")]
        public string State { get; set; }

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

        /// <summary>
        /// The reason code for a payment failure.  Possible values:
        /// "UNABLE_TO_COMPLETE_TRANSACTION",
        /// "INVALID_PAYMENT_METHOD",
        /// "PAYER_CANNOT_PAY",
        /// "CANNOT_PAY_THIS_PAYER",
        /// "REDIRECT_REQUIRED",
        /// "PAYEE_FILTER_RESTRICTIONS"
        /// </summary>
        [DataMember(Name = "failure_reason")]
        public string FailureReason { get; set; }

        /// <summary>
        /// The date and time when the payment was created, in Internet date and time format (1980-04-16T06:18:00.00Z).
        /// </summary>
        [DataMember(Name = "create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// The date and time when the payment was updated, in Internet date and time format (1980-04-16T06:18:00.00Z).
        /// </summary>
        [DataMember(Name = "update_time")]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// An array of request-related HATEOAS links
        /// </summary>
        [DataMember(Name = "links")]
        public IEnumerable<LinkDescription> Links { get; set; }
    }
}
