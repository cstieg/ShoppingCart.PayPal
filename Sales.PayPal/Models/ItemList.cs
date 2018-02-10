using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Cstieg.Sales.PayPal.Models
{
    /// <summary>
    /// Model of a list of items being sold in a transaction through PayPal Payments API.
    /// Child of Transaction
    /// </summary>
    [DataContract]
    public class ItemList
    {
        /// <summary>
        /// An array of items that are being purchased
        /// </summary>
        [Required]
        [DataMember(Name = "items")]
        public IEnumerable<Item> Items { get; set; }

        /// <summary>
        /// The shipping address details
        /// </summary>
        [DataMember(Name = "shipping_address")]
        public AddressPayPal ShippingAddress { get; set; }

        /// <summary>
        /// The shipping method for this payment, such as USPS Parcel
        /// </summary>
        [DataMember(Name = "shipping_method")]
        public string ShippingMethod { get; set; }

        /// <summary>
        /// The shipping phone number, in its canonical international format as defined b the E.164 numbering plan.  
        /// Enables merchants to share payer's contact information with PayPal for the current payment.
        /// The final contact number for the payer who is associated with the transaction might be the same as
        /// or different from the shipping_phone_number based on the payer's action on PayPal.
        /// </summary>
        [DataMember(Name = "shipping_phone_number")]
        public string ShippingPhoneNumber { get; set; }
    }
}
