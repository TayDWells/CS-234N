using NUnit.Framework;
using MMABooksBusinessClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductTests
    {
        private Product product;
        private Product def;
        private Product c;

        [SetUp]
        public void SetUp()
        {
            def = new Product();
            c = new Product("QWER", "Test Product", 10.0f, 50);
            product = new Product();
        }

        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.ProductCode);
            Assert.AreEqual(null, def.Description);
            Assert.AreEqual(0.0f, def.UnitPrice);
            Assert.AreEqual(0, def.OnHandQuantity);

            Assert.IsNotNull(c);
            Assert.AreEqual("QWER", c.ProductCode);
            Assert.AreEqual("Test Product", c.Description);
            Assert.AreEqual(10.0f, c.UnitPrice);
            Assert.AreEqual(50, c.OnHandQuantity);
        }

        [Test]
        public void ProductCodeSetterShouldSetValidValue()
        {
            var product = new Product();
            product.ProductCode = "123";
            Assert.AreEqual("123", product.ProductCode);
        }

        [Test]
        public void DescriptionSetterShouldSetValidValue()
        {
            var product = new Product();
            product.Description = "Test Description";
            Assert.AreEqual("Test Description", product.Description);
        }

        [Test]
        public void UnitPriceSetterShouldSetValidValue()
        {
            var product = new Product();
            product.UnitPrice = 10.0f;
            Assert.AreEqual(10.0f, product.UnitPrice);
        }

        [Test]
        public void OnHandQuantitySetterShouldSetValidValue()
        {
            var product = new Product();
            product.OnHandQuantity = 50;
            Assert.AreEqual(50, product.OnHandQuantity);
        }
    }
}
