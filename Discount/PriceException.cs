using System;

namespace Discount
{
    public class PriceException : Exception
    {
        public PriceException(string message) : base(message)
        {
        }
    }
}
