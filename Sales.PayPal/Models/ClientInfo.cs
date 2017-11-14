﻿using System.Runtime.Serialization;

namespace Cstieg.Sales.PayPal
{
    /// <summary>
    /// PayPal client info modeling paypal.json
    /// </summary>
    [DataContract]
    public class ClientInfo
    {
        [DataMember(Name = "client_account")]
        public string ClientAccount { get; set; }

        [DataMember(Name = "client_id")]
        public string ClientId { get; set; }

        [DataMember(Name = "client_secret")]
        public string ClientSecret { get; set; }

        [DataMember(Name = "express_checkout_access_token")]
        public string ExpressCheckoutAccessToken { get; set; }

        [DataMember(Name = "return_url")]
        public string ReturnUrl { get; set; }

        [DataMember(Name = "cancel_url")]
        public string CancelUrl { get; set; }

        [DataMember(Name = "create_payment_url")]
        public string CreatePaymentUrl { get; set; }

        [DataMember(Name = "execute_payment_url")]
        public string ExecutePaymentUrl { get; set; }

        [DataMember(Name = "mode")]
        public string Mode { get; set; }
    }
}
