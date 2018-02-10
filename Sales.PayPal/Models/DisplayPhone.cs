using System.Runtime.Serialization;

namespace Cstieg.Sales.PayPal.Models
{
    /// <summary>
    /// Model of a phone number of a customer paying through PayPalPayments API.
    /// Child of PayeeDisplayMetadata
    /// </summary>
    [DataContract]
    public class DisplayPhone : IPayPalEntity
    {
        /// <summary>
        /// The two-character ISO-3166-1 country code of the payee's country.
        /// </summary>
        [DataMember(Name = "country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// The in-country phone number, in E.164 numbering plan format.
        /// </summary>
        [DataMember(Name = "number")]
        public string Number { get; set; }
    }
}
