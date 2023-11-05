using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using MMABooksBusinessClasses;
using MMABooksDBClasses;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerDBTests
    {

        [Test]
        public void TestGetCustomer()
        {
            Customer c = CustomerDB.GetCustomer(1);
            Assert.AreEqual(1, c.CustomerID);
        }

        [Test]
        public void TestCreateCustomer()
        {
            Customer c = new Customer();
            c.Name = "Mickey Mouse";
            c.Address = "101 Main Street";
            c.City = "Orlando";
            c.State = "FL";
            c.ZipCode = "10101";

            int customerID = CustomerDB.AddCustomer(c);
            c = CustomerDB.GetCustomer(customerID);
            Assert.AreEqual("Mickey Mouse", c.Name);
        }

        [Test]
        public void TestDeleteCustomer()
        {
            // Arrange: Create a customer to be deleted
            Customer d = new Customer
            {
                CustomerID = 702,  // Set this to the customer's ID you want to delete
                Name = "Mickey Mouse",
                Address = "101 Main Street",
                City = "Orlando",
                State = "FL",
                ZipCode = "10101"
            };

            // Act: Attempt to delete the customer
            bool deletionResult = CustomerDB.DeleteCustomer(d);

            // Assert: Check if the deletion was successful
            Assert.IsTrue(deletionResult, "Customer deletion should return true for a successful deletion.");

            // Additional Assert: Verify that the customer is no longer retrievable from the database
            Customer deletedCustomer = CustomerDB.GetCustomer(d.CustomerID);
            Assert.IsNull(deletedCustomer, "Deleted customer should not exist in the database.");
        }


        [Test]
        public void TestUpdateCustomer()
        {
            // Arrange: Create an old customer and a new customer with changes
            Customer oldCustomer = new Customer
            {
                CustomerID = 701, // Set this to the actual CustomerID to update
                Name = "Mickey Mouse",
                Address = "101 Main Street",
                City = "Orlando",
                State = "FL",
                ZipCode = "10101"
            };

            Customer newCustomer = new Customer
            {
                CustomerID = 701, // Set this to the same CustomerID
                Name = "Mickey Mouse",
                Address = "123 Main Street",
                City = "Orlando",
                State = "FL",
                ZipCode = "10101"
            };

            // Act: Attempt to update the customer
            bool updateResult = CustomerDB.UpdateCustomer(oldCustomer, newCustomer);

            // Assert: Check if the update was successful
            Assert.IsTrue(updateResult, "Customer update should return true for a successful update.");
        }
    }
}
