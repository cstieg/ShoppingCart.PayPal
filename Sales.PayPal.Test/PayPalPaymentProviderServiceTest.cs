using Cstieg.Sales.Models;
using Cstieg.Sales.PayPal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Sales.PayPal.Test
{
    /// <summary>
    /// Summary description for PayPalPaymentProvideServiceTest
    /// </summary>
    [TestClass]
    public class PayPalPaymentProviderServiceTest
    {
        private string _payPalPaymentsSampleResponse = @"{
          ""id"": ""PAY-9N9834337A9191208KOZOQWI"",
          ""create_time"": ""2017-07-01T16:56:57Z"",
          ""update_time"": ""2017-07-01T17:05:41Z"",
          ""state"": ""approved"",
          ""intent"": ""order"",
          ""payer"": {
            ""payment_method"": ""paypal"",
            ""payer_info"": {
              ""email"": ""qa152-biz@paypal.com"",
              ""first_name"": ""Thomas"",
              ""last_name"": ""Miller"",
              ""payer_id"": ""PUP87RBJV8HPU"",
              ""shipping_address"": {
                ""line1"": ""4th Floor, One Lagoon Drive"",
                ""line2"": ""Unit #34"",
                ""city"": ""Redwood City"",
                ""state"": ""CA"",
                ""postal_code"": ""94065"",
                ""country_code"": ""US"",
                ""phone"": ""011862212345678"",
                ""recipient_name"": ""Thomas Miller""
              }
            }
          },
          ""transactions"": [
            {
              ""amount"": {
                ""total"": ""41.15"",
                ""currency"": ""USD"",
                ""details"": {
                  ""subtotal"": ""30.00"",
                  ""tax"": ""0.15"",
                  ""shipping"": ""11.00""
                }
        },
              ""description"": ""The payment transaction description."",
              ""item_list"": {
                ""items"": [
                  {
                    ""name"": ""hat"",
                    ""sku"": ""1"",
                    ""price"": ""3.00"",
                    ""currency"": ""USD"",
                    ""quantity"": ""5""
                  },
                  {
                    ""name"": ""handbag"",
                    ""sku"": ""34"",
                    ""price"": ""15.00"",
                    ""currency"": ""USD"",
                    ""quantity"": ""1""
                  }
                ],
                ""shipping_address"": {
                  ""recipient_name"": ""Thomas Miller"",
                  ""line1"": ""4th Floor, One Lagoon Drive"",
                  ""line2"": ""Unit #34"",
                  ""city"": ""Redwood City"",
                  ""state"": ""CA"",
                  ""phone"": ""011862212345678"",
                  ""postal_code"": ""94065"",
                  ""country_code"": ""US""
                }
              },
              ""related_resources"": [
                {
                  ""order"": {
                    ""id"": ""O-3SP845109F051535C"",
                    ""create_time"": ""2017-07-01T16:56:58Z"",
                    ""update_time"": ""2017-07-01T17:05:41Z"",
                    ""state"": ""pending"",
                    ""amount"": {
                      ""total"": ""41.15"",
                      ""currency"": ""USD""
                    },
                    ""parent_payment"": ""PAY-9N9834337A9191208KOZOQWI"",
                    ""links"": [
                      {
                        ""href"": ""https://api.sandbox.paypal.com/v1/payments/orders/O-3SP845109F051535C"",
                        ""rel"": ""self"",
                        ""method"": ""GET""
                      },
                      {
                        ""href"": ""https://api.sandbox.paypal.com/v1/payments/payment/PAY-9N9834337A9191208KOZOQWI"",
                        ""rel"": ""parent_payment"",
                        ""method"": ""GET""
                      },
                      {
                        ""href"": ""https://api.sandbox.paypal.com/v1/payments/orders/O-3SP845109F051535C/void"",
                        ""rel"": ""void"",
                        ""method"": ""POST""
                      },
                      {
                        ""href"": ""https://api.sandbox.paypal.com/v1/payments/orders/O-3SP845109F051535C/authorize"",
                        ""rel"": ""authorization"",
                        ""method"": ""POST""
                      },
                      {
                        ""href"": ""https://api.sandbox.paypal.com/v1/payments/orders/O-3SP845109F051535C/capture"",
                        ""rel"": ""capture"",
                        ""method"": ""POST""
                      }
                    ]
                  }
                }
              ]
            }
          ],
          ""links"": [
            {
              ""href"": ""https://api.sandbox.paypal.com/v1/payments/payment/PAY-9N9834337A9191208KOZOQWI"",
              ""rel"": ""self"",
              ""method"": ""GET""
            }
          ]
        }";

        private string _paypalSettingsJson = @"{
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

        private PayPalPaymentProviderService _paypalService;

        public PayPalPaymentProviderServiceTest()
        {

        }

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var ppciService = new PayPalClientInfoService(_paypalSettingsJson);
            _paypalService = new PayPalPaymentProviderService(_payPalPaymentsSampleResponse, ppciService);
        }

        [TestMethod]
        public void PaymentResponse()
        {
            // Act

            // Assert
            Assert.IsNotNull(_paypalService, "Couldn't create paypal service");
            Assert.AreEqual("PAY-9N9834337A9191208KOZOQWI", _paypalService.PaymentResponse.Id);
            Assert.AreEqual("paypal", _paypalService.PaymentResponse.Payer.PaymentMethod);
        }

        [TestMethod]
        public void GetShippingAddress()
        {
            // Act
            var shippingAddress = _paypalService.GetShippingAddress();

            // Assert
            Assert.IsNotNull(shippingAddress);
            Assert.AreEqual("4th Floor, One Lagoon Drive", shippingAddress.Address1);
        }

        [TestMethod]
        public void GetCartId()
        {
            // Act
            var cartId = _paypalService.GetCartId();

            // Assert
            Assert.AreEqual("PAY-9N9834337A9191208KOZOQWI", cartId);
        }

        [TestMethod]
        public void GetCountryCode()
        {
            // Act
            var country = _paypalService.GetCountryCode();

            // Assert
            Assert.AreEqual("US", country);
        }

        [TestMethod]
        public void GetCustomer()
        {
            // Act
            var customer = _paypalService.GetCustomer();

            // Assert
            Assert.AreEqual("Thomas Miller", customer.CustomerName);
        }

        [TestMethod]
        public void GetOrder()
        {
            // Act
            var order = _paypalService.GetOrder();

            // Assert
            Assert.IsNotNull(order);
            Assert.AreEqual(41.15M, order.Total, "Order amount is incorrect");
            Assert.AreEqual(5, order.OrderDetails.Find(o => o.ProductId == 1).Quantity, "Quantity is incorrect");
            Assert.AreEqual(11M, order.Shipping, "Shipping amount is incorrect");
        }

        [TestMethod]
        public void CreatePaymentDetails()
        {
            // Arrange
            var shoppingCart = new ShoppingCart()
            {
                Order = new Order()
                {
                    OrderDetails = new List<OrderDetail>()
                    {
                        new OrderDetail()
                        {
                             Product = new Product()
                             {
                                 Id = 1,
                                 Name = "hat",
                                 Price = 3.00M,
                                 Shipping = 1.00M
                             },
                             Quantity = 5,
                             Shipping = 1.00M,
                             UnitPrice = 3.00M
                        },
                        new OrderDetail()
                        {
                            Product = new Product()
                            {
                                Id = 2,
                                Name = "handbag",
                                Price = 15.00M,
                                Shipping = 0.50M
                            },
                            Quantity = 1,
                            Shipping = 0.50M,
                            UnitPrice = 15.00M
                        }
                    }
                }
            };

            // Act
            var paymentDetails = _paypalService.CreatePaymentDetails(shoppingCart);

            // Assert
            Assert.IsNotNull(paymentDetails);
            Assert.IsFalse(paymentDetails.Contains("null"));

        }
    }
}
