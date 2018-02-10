using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Cstieg.Sales.PayPal.Models
{
    /// <summary>
    /// Model of a Transaction through PayPal Payments API.
    /// Child of PaymentDetails
    /// </summary>
    [DataContract]
    public class Transaction : IPayPalEntity
    {
        /// <summary>
        /// Optional.  The merchant-provided ID for the purchase unit
        /// </summary>
        [StringLength(256)]
        [DataMember(Name = "reference_id")]
        public string ReferenceId { get; set; }

        /// <summary>
        /// The amount to collect
        /// </summary>
        [Required]
        [DataMember(Name = "amount")]
        public Amount Amount { get; set; }

        /// <summary>
        /// The payee who receives the funds and fulfills the order
        /// </summary>
        [DataMember(Name = "payee")]
        public Payee Payee { get; set; }

        /// <summary>
        /// The purchase description
        /// </summary>
        [StringLength(127)]
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Optional.  A note to the recipient of the funds in this transaction
        /// </summary>
        [StringLength(255)]
        [DataMember(Name = "note_to_payee")]
        public string NoteToPayee { get; set; }

        /// <summary>
        /// A free-form for the client's use
        /// </summary>
        [StringLength(127)]
        [DataMember(Name = "custom")]
        public string Custom { get; set; }

        /// <summary>
        /// The invoice number to track this payment
        /// </summary>
        [StringLength(127)]
        [DataMember(Name = "invoice_number")]
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// The purchase order number or ID.  Identifies this payment.
        /// </summary>
        [StringLength(127)]
        [DataMember(Name = "purchase_order")]
        public string PurchaseOrder { get; set; }

        /// <summary>
        /// The soft descriptor to use to charge this funding source.
        /// If the string's length is greater than the maximum allowed length, the API truncates the string.
        /// </summary>
        [StringLength(22)]
        [DataMember(Name = "soft_descriptor")]
        public string SoftDescriptor { get; set; }

        /// <summary>
        /// The payment options for this transaction
        /// </summary>
        [DataMember(Name = "payment_options")]
        public PaymentOptions PaymentOptions { get; set; }

        /// <summary>
        /// An array of items that are being purchased
        /// </summary>
        [DataMember(Name = "item_list")]
        public ItemList ItemList { get; set; }

        /// <summary>
        /// The URL to send payment notification
        /// </summary>
        [StringLength(2048)]
        [DataMember(Name = "notify_url")]
        public string NotifyUrl { get; set; }

        /// <summary>
        /// The URL on the merchant site related to this payment
        /// </summary>
        [StringLength(2048)]
        [DataMember(Name = "order_url")]
        public string OrderUrl { get; set; }

        /// <summary>
        /// An array of payment-related transactions.  A transaction defines what the payment is for and who fulfills the payment.
        /// </summary>
        //[DataMember(Name = "related_resources")]
        //public IEnumerable<RelatedResources> RelatedResources { get; set; }
    }

}
