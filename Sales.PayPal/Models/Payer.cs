using System.Runtime.Serialization;

namespace Cstieg.Sales.PayPal.Models
{
    /// <summary>
    /// Model of an entity sending funds through PayPal Payments API.
    /// Child of PaymentDetails
    /// </summary>
    [DataContract]
    public class Payer : IPayPalEntity
    {
        /// <summary>
        /// The payment method.  Possible values:
        ///   "credit_card", "paypal"
        /// </summary>
        [DataMember(Name = "payment_method")]
        public string PaymentMethod { get; set; }

        /// <summary>
        /// The status of payer's PayPal account. Readonly.  Possible values:
        ///   "VERIFIED", "UNVERIFIED"
        /// </summary>
        [DataMember(Name = "status")]
        public string Status { get; set; }

        // [DataMember(Name = "funding_instruments")
        // public IEnumerable<FundingInstrument> FundingInstruments { get; set; }

        /// <summary>
        /// The payer information
        /// </summary>
        [DataMember(Name = "payer_info")]
        public PayerInfo PayerInfo { get; set; }
    }
}
