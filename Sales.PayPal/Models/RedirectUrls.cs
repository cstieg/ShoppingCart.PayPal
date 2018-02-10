using System.Runtime.Serialization;

namespace Cstieg.Sales.PayPal.Models
{
    /// <summary>
    /// Model of URLs where the user will be directed after a payment through PayPal Payments API.
    /// Child of PaymentDetails
    /// </summary>
    [DataContract]
    public class RedirectUrls : IPayPalEntity
    {
        /// <summary>
        /// The URL where the payer is redirected after he or she approves the payment.  Required for PayPal account payments.
        /// </summary>
        [DataMember(Name = "return_url")]
        public string ReturnUrl { get; set; }

        /// <summary>
        /// The URL where the payer is redirected after he or she cancels the payment.  Required for PayPal account payments.
        /// </summary>
        [DataMember(Name = "cancel_url")]
        public string CancelUrl { get; set; }
    }
}
