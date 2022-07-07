using Discount;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject1
{
    [TestClass]
    public class UnitTestCheckCustomerDiscountTypes
    {
        [TestMethod]
        public void CheckUnregisteredCustomerDiscount()
        {
            PriceCalculator pc = new PriceCalculator();

            ICustomerAccountable c1 = new CustomerAccountable()
            {
                Id = "Customer1",
                Address = "",
                Profile = new UnregisteredCustomerDiscountProfile()
            };

            decimal amount = 100;

            decimal discountedPrice = pc.GetPrice(amount, c1);

            Assert.AreEqual(discountedPrice, amount);
        }

        [TestMethod]
        public void CheckRegisteredCustomerDiscount()
        {
            PriceCalculator pc = new PriceCalculator();

            ICustomerAccountable c1 = new CustomerAccountable()
            {
                Id = "Customer1",
                Address = "",
                Profile = new RegisteredCustomerDiscountProfile(DateTime.Now)
            };

            decimal amount = 100;

            decimal discountedPrice = pc.GetPrice(amount, c1);
            Assert.AreEqual(discountedPrice, 90.0m);

            c1.Profile = new RegisteredCustomerDiscountProfile(DateTime.Now - TimeSpan.FromDays(800));
            discountedPrice = pc.GetPrice(amount, c1);
            Assert.AreEqual(discountedPrice, 88.2m);

            c1.Profile = new RegisteredCustomerDiscountProfile(DateTime.Now - TimeSpan.FromDays(365 * 6));
            discountedPrice = pc.GetPrice(amount, c1);
            Assert.AreEqual(discountedPrice, 85.5m);
        }

        [TestMethod]
        public void CheckValuableCustomerDiscount()
        {
            PriceCalculator pc = new PriceCalculator();

            ICustomerAccountable c1 = new CustomerAccountable()
            {
                Id = "Customer1",
                Address = "",
                Profile = new ValuableCustomerDiscountProfile(DateTime.Now)
            };

            decimal amount = 100;

            decimal discountedPrice = pc.GetPrice(amount, c1);
            Assert.AreEqual(discountedPrice, 70.0m);

            c1.Profile = new ValuableCustomerDiscountProfile(DateTime.Now - TimeSpan.FromDays(800));
            discountedPrice = pc.GetPrice(amount, c1);
            Assert.AreEqual(discountedPrice, 68.6m);

            c1.Profile = new ValuableCustomerDiscountProfile(DateTime.Now - TimeSpan.FromDays(365 * 6));
            discountedPrice = pc.GetPrice(amount, c1);
            Assert.AreEqual(discountedPrice, 66.5m);
        }

        [TestMethod]
        public void CheckMostValuableCustomerDiscount()
        {
            PriceCalculator pc = new PriceCalculator();

            ICustomerAccountable c1 = new CustomerAccountable()
            {
                Id = "Customer1",
                Address = "",
                Profile = new MostValuableCustomerDiscountProfile(DateTime.Now)
            };

            decimal amount = 100;

            decimal discountedPrice = pc.GetPrice(amount, c1);
            Assert.AreEqual(discountedPrice, 50.0m);

            c1.Profile = new MostValuableCustomerDiscountProfile(DateTime.Now - TimeSpan.FromDays(800));
            discountedPrice = pc.GetPrice(amount, c1);
            Assert.AreEqual(discountedPrice, 49.0m);

            c1.Profile = new MostValuableCustomerDiscountProfile(DateTime.Now - TimeSpan.FromDays(365 * 6));
            discountedPrice = pc.GetPrice(amount, c1);
            Assert.AreEqual(discountedPrice, 47.5m);
        }
    }
}
