namespace Discount
{
    public class UnregisteredCustomerDiscountProfile : CustomerDiscountProfile, IUnregisteredCustomerDiscountProfile
    {
        public override decimal GetDiscountRatio()
        {
            return 0;
        }
    }
}
