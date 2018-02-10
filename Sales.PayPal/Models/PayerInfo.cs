using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Cstieg.Sales.PayPal.Models
{
    /// <summary>
    /// Model of information about an entity sending funds through PayPal Payments API.
    /// Child of Payer
    /// </summary>
    [DataContract]
    public class PayerInfo : IPayPalEntity
    {
        /// <summary>
        /// The payer's email address
        /// </summary>
        [StringLength(127)]
        [DataMember(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// The payer's salutation.  Readonly
        /// </summary>
        [DataMember(Name = "salutation")]
        public string Salutation { get; set; }

        /// <summary>
        /// The payer's first name
        /// </summary>
        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// The payer's middle name
        /// </summary>
        [DataMember(Name = "middle_name")]
        public string MiddleName { get; set; }

        /// <summary>
        /// The payer's last name
        /// </summary>
        [DataMember(Name = "last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// The payer's suffix
        /// </summary>
        [DataMember(Name = "suffix")]
        public string Suffix { get; set; }

        /// <summary>
        /// The PayPal-assigned encrypted payer ID
        /// </summary>
        [DataMember(Name = "payer_id")]
        public string PayerId { get; set; }

        /// <summary>
        /// The payer's phone number
        /// </summary>
        [StringLength(20)]
        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        /// <summary>
        /// The phone type.  Possible values:
        ///   "HOME", "WORK", "MOBILE", "OTHER"
        /// </summary>
        [DataMember(Name = "phone_type")]
        public string PhoneType { get; set; }

        /// <summary>
        /// The birth date of the payer, in Internet date format.  For example, "1990-04-12"
        /// </summary>
        [DataMember(Name = "birth_date")]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// The payer's tax ID type.
        /// Supported for the PayPal payment method only.
        /// </summary>
        [DataMember(Name = "tax_id_type")]
        public string TaxIdType { get; set; }

        /// <summary>
        /// The payer's two-character ISO-3166-1 country code
        /// </summary>
        [DataMember(Name = "country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// The payer's billing address
        /// </summary>
        [DataMember(Name = "billing_address")]
        public AddressPayPal BillingAddress { get; set; }

        // DEPRECATED, but still used, apparently
        [DataMember(Name = "shipping_address")]
        public AddressPayPal ShippingAddress { get; set; }

    }
}
