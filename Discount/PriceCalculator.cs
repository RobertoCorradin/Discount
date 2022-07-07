namespace Discount
{
    public interface IPriceCalculator
    {
        public decimal GetPrice(decimal amount, ICustomerAccountable customer);
    }

    public class PriceCalculator : IPriceCalculator
    {
        public decimal GetPrice(decimal amount, ICustomerAccountable customer)
        {
            ICustomerDiscountProfile profile = customer?.Profile;
            if (profile == null)
                throw new PriceException("Invalid customer profile");

            decimal discountRatio = profile.GetDiscountRatio();
            if (discountRatio < 0.0m || discountRatio > 1.0m)
                throw new PriceException($"Invalid discount ratio {discountRatio}");

            return amount - amount * discountRatio;
        }
    }
}
