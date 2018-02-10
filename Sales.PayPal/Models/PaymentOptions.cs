using System.Runtime.Serialization;

namespace Cstieg.Sales.PayPal.Models
{
    /// <summary>
    /// Model of payment options for a payment through PayPal Payments API.
    /// Child of Transactions
    /// </summary>
    [DataContract]
    public class PaymentOptions : IPayPalEntity
    {
        /// <summary>
        /// The payment method for this transaction.  This field does not apply to the credit card payment method.  Possible values:
        ///   "UNRESTRICTED", "INSTANT_FUNDING_SOURCE", "IMMEDIATE_PAY"
        /// </summary>
        [DataMember(Name = "allowed_payment_method")]
        public string AllowedPaymentMethod { get; set; }
    }
}
