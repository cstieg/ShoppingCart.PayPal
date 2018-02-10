using System.Collections.Generic;
using System.Linq;
using Cstieg.Sales.Interfaces;
using Cstieg.Sales.Models;
using Cstieg.Sales.PayPal.Exceptions;
using Cstieg.Sales.PayPal.Models;
using Newtonsoft.Json;

namespace Cstieg.Sales.PayPal
{
    /// <summary>
    /// Service to interface between PayPal's client-side Payment API and Cstieg.Sales.ShoppingCart
    /// </summary>
    public class PayPalPaymentProviderService : IPaymentProviderService
    {
        // Payment
        public PaymentResponse PaymentResponse { get; set; }
        public PayPalClientInfoService ClientInfoService { get; set; }
        public string Currency { get; set; } = "USD";

        private PayPalClientAccount _clientAccount;

        /// <summary>
        /// Empty constructor
        /// </summary>
        public PayPalPaymentProviderService() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clientInfoService">ClientInfoService object containing client id info for PayPal account</param>
        public PayPalPaymentProviderService(PayPalClientInfoService clientInfoService)
        {
            ClientInfoService = clientInfoService;
            _clientAccount = clientInfoService.GetClientAccount();
        }

        /// <summary>
        /// Constructor accepting PaymentResponse object from PayPal Create Payment API call
        /// </summary>
        /// <param name="response">PaymentResponse object from PayPal Create Payment API call</param>
        /// <param name="clientInfoService">ClientInfoService object containing client id info for PayPal account</param>
        public PayPalPaymentProviderService(PaymentResponse response, PayPalClientInfoService clientInfoService)
        {
            PaymentResponse = response;
            ClientInfoService = clientInfoService;
            _clientAccount = clientInfoService.GetClientAccount();
        }

        /// <summary>
        /// Constructor accepting the raw JSON payment response from PayPal Create Payment API call
        /// </summary>
        /// <param name="response">Raw JSON payment response from PayPal Create Payment API call</param>
        /// <param name="clientInfoService">ClientInfoService object containing client id info for PayPal account</param>
        public PayPalPaymentProviderService(string response, PayPalClientInfoService clientInfoService)
        {
            PaymentResponse = SetPaymentResponse(response);
            ClientInfoService = clientInfoService;
            _clientAccount = clientInfoService.GetClientAccount();
        }

        /// <summary>
        /// Converts a raw JSON string containing the payment response from PayPal to a PaymentResponse object, and stores it to the instance.
        /// </summary>
        /// <param name="response">Raw JSON payment response from PayPal Create Payment API call</param>
        /// <returns>PaymentResponse object</returns>
        public PaymentResponse SetPaymentResponse(string response)
        {
            PaymentResponse = JsonConvert.DeserializeObject<PaymentResponse>(response);
            return PaymentResponse;
        }

        public IAddress GetBillingAddress()
        {
            // Return shipping address if billing address is null
            try
            {
                return PaymentResponse.Payer.PayerInfo.BillingAddress;
            }
            catch
            {
                return GetShippingAddress();
            }
        }

        public IAddress GetShippingAddress()
        {
            // According to docs, this should be correct.  However, in practice, PayPal returns shipping address in PayerInfo
            //return PaymentResponse.Transactions.First().ItemList.ShippingAddress;
            return PaymentResponse.Payer.PayerInfo.ShippingAddress;
        }

        public string GetCartId()
        {
            return PaymentResponse.Id;
        }

        public string GetCountryCode()
        {
            return GetShippingAddress().Country;
        }

        public ICustomer GetCustomer()
        {
            PayerInfo pi = PaymentResponse.Payer.PayerInfo;
            return new Customer()
            {
                FirstName = pi.FirstName,
                LastName = pi.LastName,
                EmailAddress = pi.Email
            };
        }

        public IOrder GetOrder()
        {
            var order = new Order()
            {
                Cart = PaymentResponse.Id,
                Tax = PaymentResponse.Transactions.First().Amount.AmountDetails.Tax,
                NoteToPayee = PaymentResponse.Transactions.First().NoteToPayee
            };
            IEnumerable<Item> itemList = PaymentResponse.Transactions.First().ItemList.Items;
            foreach(var item in itemList)
            {
                order.OrderDetails.Add(new OrderDetail()
                {
                    ProductId = int.Parse(item.Sku),
                    Quantity = item.Quantity,
                    UnitPrice = item.Price
                });
            }

            // Put shipping charges for entire order on the first order detail, so total will match total in shopping cart on verification
            order.OrderDetails.First().Shipping = PaymentResponse.Transactions.First().Amount.AmountDetails.Shipping;
            return order;
        }

        /// <summary>
        /// Creates the payment details that need to be passed to PayPal API to create payment
        /// </summary>
        /// <param name="shoppingCart">Shopping cart to check out</param>
        /// <returns>A JSON string containing the payment details</returns>
        public string CreatePaymentDetails(IShoppingCart shoppingCart)
        {
            PaymentDetails data = new PaymentDetails()
            {
                Intent = "sale",
                Payer = new Payer()
                {
                    PaymentMethod = "paypal"
                },
                Transactions = new List<Transaction>
                {
                    new Transaction()
                    {
                        Amount = new Amount
                        {
                            Currency = Currency,
                            Total = shoppingCart.GrandTotal,
                            AmountDetails = new AmountDetails
                            {
                                Shipping = shoppingCart.TotalShipping,
                                Subtotal = shoppingCart.TotalExtendedPrice,
                                Tax = shoppingCart.Order.Tax
                            }
                        },
                        Payee = new Payee()
                        {
                            Email = _clientAccount.ClientAccount
                        },
                        Description = shoppingCart.Order.Description,
                        ItemList = new ItemList()
                        {
                            Items = GetPayPalItems(shoppingCart)
                        }
                    }
                },
                RedirectUrls = new RedirectUrls
                {
                    ReturnUrl = _clientAccount.ReturnUrl,
                    CancelUrl = _clientAccount.CancelUrl
                }
            };
            string dataJSON = JsonConvert.SerializeObject(data, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            return dataJSON;
        }

        /// <summary>
        /// Converts shopping cart info to PayPal object format
        /// </summary>
        /// <param name="shoppingCart">Shopping cart containing items to be purchased</param>
        /// <returns>Shopping cart items in PayPal object format</returns>
        private List<Item> GetPayPalItems(IShoppingCart shoppingCart)
        {
            List<Item> items = new List<Item>();
            List<OrderDetail> shoppingCartItems = shoppingCart.Order.OrderDetails;
            if (shoppingCartItems.Count == 0)
            {
                throw new NoDataException("There are no items in the shopping cart!  Please add your items again.");
            }

            for (int i = 0; i < shoppingCartItems.Count; i++)
            {
                items.Add(GetPayPalItem(shoppingCartItems[i]));
            }
            return items;
        }

        /// <summary>
        /// Converts OrderDetail model to PayPal item format
        /// </summary>
        /// <param name="orderDetail">OrderDetail object containing item being purchased</param>
        /// <returns>Purchase item in PayPal object format</returns>
        private Item GetPayPalItem(OrderDetail orderDetail)
        {
            return new Item
            {
                Name = orderDetail.Product.Name,
                Quantity = orderDetail.Quantity,
                Price = orderDetail.UnitPrice,
                Sku = orderDetail.Product.Id.ToString(),
                Currency = Currency
            };
        }

    }
}
