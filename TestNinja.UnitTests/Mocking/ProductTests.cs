using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void GetPrice_GoldCustomer_ReturnReducedPrice()
        {
            var product = new Product() { ListPrice = 100 };
            var customer = new Customer() { IsGold = true };

            var result = product.GetPrice(customer);

            Assert.That(result, Is.EqualTo(70));
        }

        [Test]
        public void GetPrice_NonGoldCustomer_ReturnFullPrice()
        {
            var product = new Product() { ListPrice = 100 };
            var customer = new Customer() { IsGold = false };

            var result = product.GetPrice(customer);

            Assert.That(result, Is.EqualTo(100));
        }
    }
}
