using Cstieg.Geography;
using System.Runtime.Serialization;

namespace Cstieg.ShoppingCart.PayPal
{
    [DataContract]
    public class PayPalAddress : AddressBase
    {
        [DataMember(Name = "street_address")]
        public override string Address1 { get; set; }

        [DataMember(Name = "locality")]
        public override string City { get; set; }

        [DataMember (Name = "region")]
        public override string State { get; set; }

        [DataMember (Name = "postal_code")]
        public override string PostalCode { get; set; }

        [DataMember(Name = "country")]
        public override string Country { get; set; }
    }
}