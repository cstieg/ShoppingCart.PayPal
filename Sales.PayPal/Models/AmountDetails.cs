using System.Runtime.Serialization;

namespace Cstieg.Sales.PayPal.Models
{
    /// <summary>
    /// Model of the details of an amount paid through PayPal Payments API.
    /// Child of Amount
    /// </summary>
    [DataContract]
    public class AmountDetails : IPayPalEntity
    {
        /// <summary>
        /// The subtotal amount for the items.  
        /// If the request includes line items, this property is required.  
        /// Maximum length is 10 characters, including 2 digits after the decimal point.
        /// </summary>
        [DataMember(Name = "subtotal")]
        public decimal Subtotal { get; set; }

        /// <summary>
        /// The shipping fee. Maximum length is 10 characters, including 2 digits after the decimal point.
        /// </summary>
        [DataMember(Name = "shipping")]
        public decimal Shipping { get; set; }

        /// <summary>
        /// The tax. Maximum length is 10 characters, including 2 digits after the decimal point.
        /// </summary>
        [DataMember(Name = "tax")]
        public decimal Tax { get; set; }

        /// <summary>
        /// The handling fee. Maximum length is 10 characters, including 2 digits after the decimal point.
        /// </summary>
        [DataMember(Name = "handling_fee")]
        public decimal HandlingFee { get; set; }

        /// <summary>
        /// The shipping fee discount. Maximum length is 10 characters, including 2 digits after the decimal point.
        /// Supported for the PayPal payment method only.
        /// </summary>
        [DataMember(Name = "shipping_discount")]
        public decimal ShippingDiscount { get; set; }

        /// <summary>
        /// The insurance fee.  Maximum length is 10 characters, including 2 digits after the decimal point.
        /// Supported only for the PayPal payment method.
        /// </summary>
        [DataMember(Name = "insurance")]
        public decimal Insurance { get; set; }

        /// <summary>
        /// The gift wrap fee. Maximum length is 10 characters, including 2 digits after the decimal point.
        /// </summary>
        [DataMember(Name = "gift_wrap")]
        public decimal GiftWrap { get; set; }
    }
}
