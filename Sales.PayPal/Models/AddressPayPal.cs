using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Cstieg.Sales.PayPal.Models
{
    /// <summary>
    /// Model of an Address received from PayPal Payments API for a user's shipping or billing address
    /// </summary>
    [DataContract]
    public class AddressPayPal : Sales.Models.Address, IPayPalEntity
    {
        /// <summary>
        /// The name of the recipient at this address
        /// </summary>
        [StringLength(127)]
        [DataMember(Name = "recipient_name")]
        public override string Recipient { get; set; }

        /// <summary>
        /// The first line of the address.  For example, number, street, and so on.
        /// </summary>
        [Required]
        [DataMember(Name = "line1")]
        public override string Address1 { get; set; }

        /// <summary>
        /// Optional.  The second line of the address.  For example, suite, apartment number, and so on.
        /// </summary>
        [DataMember(Name = "line2")]
        public override string Address2 { get; set; }

        /// <summary>
        /// The city name
        /// </summary>
        [DataMember(Name = "city")]
        public override string City { get; set; }

        /// <summary>
        /// The code for a US state or the equivalent for other countries.
        /// Required for transactions if the address is in one of these countries:
        ///   Argentina, Brazil, Canada, India, Italy, Japan, Mexico, Thailand, or United States
        /// </summary>
        [DataMember(Name = "state")]
        public override string State { get; set; }

        /// <summary>
        /// The postal code, which is the zip code or equivalent.  
        /// Typically required for countries with a postal code or an equivalent.
        /// </summary>
        [DataMember(Name = "postal_code")]
        public override string PostalCode { get; set; }

        /// <summary>
        /// A two-character ISO 3166-1 code that identifies the country or region
        /// </summary>
        [Required]
        [DataMember(Name = "country_code")]
        public override string Country { get; set; }

        /// <summary>
        /// The phone number, in E.123 format
        /// </summary>
        [StringLength(50)]
        [DataMember(Name = "phone")]
        public override string Phone { get; set; }

        /// <summary>
        /// The address status.  Possible values:
        ///   "CONFIRMED", "UNCONFIRMED"
        /// </summary>
        [DataMember(Name = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The type of address: For example,
        ///   "HOME_OR_WORK", "GIFT", and so on.
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}
