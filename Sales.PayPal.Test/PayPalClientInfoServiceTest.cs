using System.Collections.Generic;
using Cstieg.Sales.PayPal;
using Cstieg.Sales.PayPal.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sales.PayPal.Test
{
    [TestClass]
    public class PayPalClientInfoServiceTest
    {
        [TestMethod]
        public void GetClientInfo()
        {
            // Arrange
             string _paypalSettingsJson = @"{
                ""mode"": ""sandbox"",
                ""accounts"": [
                  {
                    ""mode"": ""production"",
                    ""client_account"": ""stieg_d@yahoo.com"",
                    ""client_id"": ""AVhXyBpehMOaxxdKZqiozPeQKwUmEmDQfAcyV2sqUuq_aQrQMjs3bWcldHzPcSh4kZz8WqZbowFxH6_w"",
                    ""return_url"": ""https://www.deerflypatches.com"",
                    ""cancel_url"": ""https://www.deerflypatches.com""
                  },
                  {
                    ""mode"": ""sandbox"",
                    ""client_account"": ""cstieg4899-facilitator @yahoo.com"",
                    ""client_id"": ""AaLYEqNuR4sUTr6y7l7riLn6GhJDv6YY-1LrWwIyRHrRmXOlQjGscB8MQTUY_9unYy4SRSzhdVvRQ9_m"",
                    ""return_url"": ""http://www.example.com"",
                    ""cancel_url"": ""http://www.example.com""
                  }
                ]
              }";

            var ppciService = new PayPalClientInfoService(_paypalSettingsJson);

            // Act
            var clientInfo = ppciService.ClientInfo;

            // Assert
            var accounts = new List<PayPalClientAccount>(clientInfo.Accounts);
            Assert.IsNotNull(clientInfo.Accounts, "Accounts must not be null.");
            Assert.AreEqual(2, accounts.Count, "Should be two accounts.");
            Assert.AreEqual("production", accounts[0].Mode, "First account should be production.");
            Assert.AreEqual("http://www.example.com", accounts[1].ReturnUrl, "Should set returnUrl.");
        }
    }
}
