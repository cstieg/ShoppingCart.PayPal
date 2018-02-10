using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Cstieg.Sales.PayPal.Models
{
    /// <summary>
    /// Model of an item being sold through PayPal Payments API.
    /// Child of ItemList
    /// </summary>
    [DataContract]
    public class Item : IPayPalEntity
    {
        /// <summary>
        /// The stock keeping unit (SKU) for the item
        /// </summary>
        [StringLength(127)]
        [DataMember(Name = "sku")]
        public string Sku { get; set; }

        /// <summary>
        /// The item name
        /// </summary>
        [Required]
        [StringLength(127)]
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The item description.
        /// Supported only for the PayPal payment method.
        /// </summary>
        [StringLength(127)]
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// The item quantity.  Maximum length is 10 characters.
        /// </summary>
        [Required]
        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// The item cost.  Maximum length is 10 characters, including 2 digits after the decimal point.
        /// </summary>
        [Required]
        [DataMember(Name = "price")]
        public decimal Price { get; set; }

        /// <summary>
        /// The three-character ISO-4217 currency code
        /// </summary>
        [Required]
        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The item tax.  Supported only for the PayPal payment method.
        /// </summary>
        [DataMember(Name = "tax")]
        public decimal Tax { get; set; }

        /// <summary>
        /// The URL to item information.  Available to the payer in the transaction history.
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; set; }
    }

}
