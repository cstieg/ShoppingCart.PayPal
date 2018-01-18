using System;

namespace Sales.PayPal.Exceptions
{
    /// <summary>
    /// Thrown when an object is passed containing no data, such as no items in a shopping cart
    /// </summary>
    class NoDataException : Exception
    {
        public NoDataException() { }

        public NoDataException(string message) : base(message) { }
    }
}
