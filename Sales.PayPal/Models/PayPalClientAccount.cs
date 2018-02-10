using System.Runtime.Serialization;

namespace Cstieg.Sales.PayPal.Models
{
    /// <summary>
    /// PayPal client account information needed to call PayPal's client-side Payment API
    /// </summary>
    [DataContract]
    public class PayPalClientAccount
    {
        /// <summary>
        /// Which type of account.  Possible values: "product", "sandbox"
        /// </summary>
        [DataMember(Name = "mode")]
        public string Mode { get; set; }

        /// <summary>
        /// Email address associated with the account
        /// </summary>
        [DataMember(Name = "client_account")]
        public string ClientAccount { get; set; }

        /// <summary>
        /// 80 character ID identifying the account
        /// </summary>
        [DataMember(Name = "client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Url for redirect after successful payment
        /// </summary>
        [DataMember(Name = "return_url")]
        public string ReturnUrl { get; set; }

        /// <summary>
        /// Url for redirect after cancel payment
        /// </summary>
        [DataMember(Name = "cancel_url")]
        public string CancelUrl { get; set; }
    }
}
