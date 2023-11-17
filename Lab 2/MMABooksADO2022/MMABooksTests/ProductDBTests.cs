using System;
using System.Collections.Generic;
using System.Text;
using MMABooksBusinessClasses;
using MMABooksDBClasses;
using NUnit.Framework;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductDBTests
    {

        [Test]
        public void TestGetProduct()
        {
            Product p = ProductDB.GetProduct("A4CS");
            Assert.AreEqual("A4CS", p.ProductCode);
        }

        [Test]
        public void TestCreateProduct()
        {
            Product p = new Product();
            p.ProductCode = "101";
            p.Description = "Test Product";
            p.UnitPrice = 19.99f;
            p.OnHandQuantity = 50;

            string productCode = ProductDB.AddProduct(p);
            p = ProductDB.GetProduct(productCode);
            Assert.AreEqual("101", p.ProductCode);
        }

        [Test]
        public void TestDeleteProduct()
        {
            // Arrange: Create a product to be deleted
            Product d = new Product
            {
                ProductCode = "101",  
                Description = "Test Product",
                UnitPrice = 19.99f,
                OnHandQuantity = 50
            };

            // Act: Attempt to delete the product
            bool deletionResult = ProductDB.DeleteProduct(d);

            // Assert: Check if the deletion was successful
            Assert.IsTrue(deletionResult, "Product deletion should return true for a successful deletion.");

            // Additional Assert: Verify that the product is no longer retrievable from the database
            Product deletedProduct = ProductDB.GetProduct(d.ProductCode);
            Assert.IsNull(deletedProduct, "Deleted product should not exist in the database.");
        }

        [Test]
        public void TestUpdateProduct()
        {
            // Arrange: Create an old product and a new product with changes
            Product oldProduct = new Product
            {
                ProductCode = "101", // Now treating ProductCode as a string
                Description = "Test Product",
                UnitPrice = 19.99f,
                OnHandQuantity = 50
            };

            Product newProduct = new Product
            {
                ProductCode = "ABCD", // Now treating ProductCode as a string
                Description = "Updated Product",
                UnitPrice = 19.99f,
                OnHandQuantity = 50
            };

            // Act: Attempt to update the product
            bool updateResult = ProductDB.UpdateProduct(oldProduct, newProduct);

            // Assert: Check if the update was successful
            Assert.IsTrue(updateResult, "Product update should return true for a successful update.");
        }
    }
}
