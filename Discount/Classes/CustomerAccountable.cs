namespace Discount
{
    public class CustomerAccountable : Customer, ICustomerAccountable
    {
        public ICustomerDiscountProfile Profile { get; set; }
    }
}
