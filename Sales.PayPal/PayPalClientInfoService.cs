using Cstieg.Sales.PayPal.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cstieg.Sales.PayPal
{
    /// <summary>
    /// Service to get PayPal API client id and other info out of JSON file
    /// </summary>
    public class PayPalClientInfoService
    {
        private string _clientInfoJson;

        public PayPalClientInfo ClientInfo { get; set; }

        /// <summary>
        /// Constructor for PayPalClientInfoService
        /// </summary>
        /// <param name="clientInfoJson">JSON string containing PayPal client info</param>
        public PayPalClientInfoService(string clientInfoJson)
        {
            _clientInfoJson = clientInfoJson;
            ClientInfo = JsonConvert.DeserializeObject<PayPalClientInfo>(clientInfoJson);
        }

        /// <summary>
        /// Gets a single PayPal client account matching the type of account specified in the Mode element
        /// </summary>
        /// <returns>ClientAccount object containing client id info</returns>
        public PayPalClientAccount GetClientAccount()
        {
            return new List<PayPalClientAccount>(ClientInfo.Accounts).Find(c => c.Mode == ClientInfo.Mode);
        }
    }
}
