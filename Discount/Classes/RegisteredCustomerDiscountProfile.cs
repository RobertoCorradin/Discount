using System;

namespace Discount
{
    public class RegisteredCustomerDiscountProfile : CustomerDiscountProfile, IRegisteredCustomerDiscountProfile
    {
        private const decimal DefaultBasicDiscountRatio = 0.1m;
        private const int MaxYearsForDiscountCompute = 5;

        public RegisteredCustomerDiscountProfile(DateTime registeringDateTime)
        {
            RegisteringDateTime = registeringDateTime;
        }

        public DateTime RegisteringDateTime { get; set; }

        public virtual decimal BasicDiscountRatio { get; set; } = DefaultBasicDiscountRatio;

        public virtual decimal GetAdditionalDiscountRatio()
        {
            TimeSpan ts = DateTime.Now - RegisteringDateTime;   //Get the difference between now and the registering time

            int years = (int)(ts.TotalDays / 365.0);

            years = Math.Max(years, 0);

            int years_for_discount_compute = Math.Min(years, MaxYearsForDiscountCompute);

            return (decimal)years_for_discount_compute / 100;
        }

        public override decimal GetDiscountRatio()
        {
            decimal additionalDiscountRatio = GetAdditionalDiscountRatio();

            return BasicDiscountRatio + additionalDiscountRatio - BasicDiscountRatio * additionalDiscountRatio;
        }
    }
}
