using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Cstieg.Sales.PayPal.Models
{
    /// <summary>
    /// Model of a URL link which is part of a transaction through PayPal Payments API.
    /// </summary>
    [DataContract]
    public class LinkDescription : IPayPalEntity
    {
        /// <summary>
        /// The complete target URL.  
        /// To make the related call, combine the method with this link, in URL template format. 
        /// Include the $ , ( , and ) characters for pre-processing. 
        /// The href is the key HATEOS component that links a completed call with a subsequent call.
        /// </summary>
        [Required]
        [DataMember(Name = "href")]
        public string Href { get; set; }

        /// <summary>
        /// The link relation type, which serves as an ID for a link that unambiguously describes the semantics of the link.
        /// </summary>
        [Required]
        [DataMember(Name = "rel")]
        public string Rel { get; set; }

        /// <summary>
        /// The HTTP method required to make the related call. Possible values:
        /// "GET", "POST", "PUT", "DELETE", "HEAD", "CONNECT", "OPTIONS", "PATCH"
        /// </summary>
        [DataMember(Name = "method")]
        public string Method { get; set; }
    }
}
