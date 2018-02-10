using System.Runtime.Serialization;

namespace Cstieg.Sales.PayPal.Models
{
    /// <summary>
    /// Model of an entity receiving funds through PayPal Payments API.
    /// Child of Transaction
    /// </summary>
    [DataContract]
    public class Payee : IPayPalEntity
    {
        /// <summary>
        /// The email address associated with the payee's PayPal account.
        /// If the provided email address is not associated with any PayPal account, the payee can only receive PayPal Wallet payments.
        /// Direct credit card payments are denied due to card compliance requirements.
        /// </summary>
        [DataMember(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// The encrypted PayPal account ID for the payee
        /// </summary>
        [DataMember(Name = "merchant_id")]
        public string MerchantId { get; set; }

        /// <summary>
        /// The display-only metadata for the payee
        /// </summary>
        [DataMember(Name = "payee_display_metadata")]
        public PayeeDisplayMetadata PayeeDisplayMetadata { get; set; }
    }
}
