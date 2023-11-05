using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using MMABooksBusinessClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerTests
    {
        private Customer def;
        private Customer c;

        [SetUp]
        public void Setup()
        {
            def = new Customer();
            c = new Customer(1, "Donald, Duck", "101 Maple Street", "Orlando", "FL", "10001");
        }

        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(def);
            Assert.AreEqual(null, def.Name);
            Assert.AreEqual(null, def.Address);
            Assert.AreEqual(null, def.City);
            Assert.AreEqual(null, def.State);
            Assert.AreEqual(null, def.ZipCode);

            Assert.IsNotNull(c);
            Assert.AreNotEqual(null, c.Name);
            Assert.AreNotEqual(null, c.Address);
            Assert.AreNotEqual(null, c.City);
            Assert.AreNotEqual(null, c.State);
            Assert.AreNotEqual(null, c.ZipCode);
        }

        [Test]
        public void TestNameSetter()
        {
            c.Name = "Daisy, Duck";
            Assert.AreNotEqual("Donald, Duck", c.Name);
            Assert.AreEqual("Daisy, Duck", c.Name);
        }

        [Test]
        public void TestSettersNameTooLong()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.Name = "0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789");
        }

        [Test]
        public void TestAddressSetter()
        {

        }

        [Test]
        public void TestCitySetter()
        {
            c.City = "Duckburg";
            Assert.AreNotEqual("Orlando", c.City);
            Assert.AreEqual("Duckburg", c.City);
        }

        [Test]
        public void TestStateSetter()
        {
            c.State = "CA";
            Assert.AreNotEqual("FL", c.State);
            Assert.AreEqual("CA", c.State);
        }

        [Test]
        public void TestZipCodeSetter()
        {
            c.ZipCode = "90210";
            Assert.AreNotEqual("10001", c.ZipCode);
            Assert.AreEqual("90210", c.ZipCode);
        }

        [Test]
        public void TestSettersInvalidZipCode()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => c.ZipCode = "12345678901");
        }

        [Test]
        public void TestToString()
        {
            string expected = "Customer ID: 1\nName: Donald, Duck\nAddress: 101 Maple Street\nCity: Orlando\nState: FL\nZip Code: 10001";
            Assert.AreEqual(expected, c.ToString());
        }
    }
}
