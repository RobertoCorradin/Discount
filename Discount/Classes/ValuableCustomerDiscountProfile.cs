using System;

namespace Discount
{
    public class ValuableCustomerDiscountProfile : RegisteredCustomerDiscountProfile, IValuableCustomerDiscountProfile
    {
        private const decimal DefaultBasicDiscountRatio = 0.3m;

        public override decimal BasicDiscountRatio { get; set; } = DefaultBasicDiscountRatio;

        public ValuableCustomerDiscountProfile(DateTime registeringDateTime) : base(registeringDateTime)
        {
        }
    }
}
