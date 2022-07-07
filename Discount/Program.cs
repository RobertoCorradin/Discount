using System;

namespace Discount
{
    class Program
    {
        static void Main(string[] args)
        {
            SomeTest();
        }

        public static void SomeTest()
        {
            PriceCalculator pc = new PriceCalculator();

            CustomerAccountable c1 = new CustomerAccountable() 
            { 
                Id = "Customer1", 
                Address = "", 
                Profile = new UnregisteredCustomerDiscountProfile() 
            };

            decimal amount = 100.0m;

            //Now the customer c1 is unregistered
            try
            {
                Console.WriteLine($"Final price for customer = {pc.GetPrice(amount, c1)}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Change profile of customer c1 to registered and force registered date back more than 5 years ago for debug purpose
            c1.Profile = new RegisteredCustomerDiscountProfile(DateTime.Now - TimeSpan.FromDays(365 * 6));
            try
            {
                Console.WriteLine($"Final price for customer = {pc.GetPrice(amount, c1)}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Change profile of customer c1 to valuable and force registered date back more than 2 years ago for debug purpose
            c1.Profile = new ValuableCustomerDiscountProfile(DateTime.Now - TimeSpan.FromDays(400));
            try
            {
                Console.WriteLine($"Final price for customer = {pc.GetPrice(amount, c1)}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Change profile of customer c1 to mostvaluable and force registered date back more than 2 years ago for debug purpose
            c1.Profile = new MostValuableCustomerDiscountProfile(DateTime.Now - TimeSpan.FromDays(400));
            try
            {
                Console.WriteLine($"Final price for customer = {pc.GetPrice(amount, c1)}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
