using System;

namespace Discount
{
    public interface IRegisteredCustomerDiscountProfile : ICustomerDiscountProfile
    {
        public DateTime RegisteringDateTime { get; set; }

        public decimal BasicDiscountRatio { get; set; }

        public decimal GetAdditionalDiscountRatio();
    }
}
