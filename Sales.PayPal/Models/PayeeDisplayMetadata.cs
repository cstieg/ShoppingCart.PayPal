using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Cstieg.Sales.PayPal.Models
{
    /// <summary>
    /// Model of metadata for an entity receiving funds through PayPal Payments API.
    /// Child of Payee
    /// </summary>
    [DataContract]
    public class PayeeDisplayMetadata : IPayPalEntity
    {
        /// <summary>
        /// The email address for the payee.
        /// </summary>
        [StringLength(127)]
        [DataMember(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// The payee's phone number
        /// </summary>
        [DataMember(Name = "display_phone")]
        public DisplayPhone DisplayPhone { get; set; }

        /// <summary>
        /// The payee's business name
        /// </summary>
        [DataMember(Name = "brand_name")]
        public string BrandName { get; set; }
    }
}
