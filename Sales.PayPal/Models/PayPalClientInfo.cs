using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Cstieg.Sales.PayPal.Models
{
    /// <summary>
    /// PayPal client info modeling paypal.json
    /// </summary>
    [DataContract]
    public class PayPalClientInfo
    {
        /// <summary>
        /// Which type of account.  Possible values: "product", "sandbox"
        /// </summary>
        [DataMember(Name = "mode")]
        public string Mode { get; set; }

        /// <summary>
        /// List of accounts (production and sandbox)
        /// </summary>        
        [DataMember(Name = "accounts")]
        public IEnumerable<PayPalClientAccount> Accounts { get; set; }
    }
}
