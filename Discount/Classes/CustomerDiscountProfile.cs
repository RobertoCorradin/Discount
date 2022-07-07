namespace Discount
{
    public abstract class CustomerDiscountProfile : ICustomerDiscountProfile
    {
        public abstract decimal GetDiscountRatio();
    }
}
