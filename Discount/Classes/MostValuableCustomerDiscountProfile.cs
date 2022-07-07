using System;

namespace Discount
{
    public class MostValuableCustomerDiscountProfile : ValuableCustomerDiscountProfile, IMostValuableCustomerDiscountProfile
    {
        private const decimal DefaultBasicDiscountRatio = 0.5m;

        public override decimal BasicDiscountRatio { get; set; } = DefaultBasicDiscountRatio;

        public MostValuableCustomerDiscountProfile(DateTime registeringDateTime) : base(registeringDateTime)
        {
        }
    }
}
