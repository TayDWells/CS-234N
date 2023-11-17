using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksBusinessClasses
{
    public class Product
    {
        public Product() { }

        public Product(string code, string description, float price, int quantity)
        {
            ProductCode = code;
            Description = description;
            UnitPrice = price;
            OnHandQuantity = quantity;
        }

        private string productCode;
        private string description;
        private float unitPrice;
        private int onHandQuantity;

        public string ProductCode
        {
            get
            {
                return productCode;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                    productCode = value;
                else
                    throw new ArgumentException("Product Code cannot be null or empty");
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length <= 100)
                    description = value;
                else
                    throw new ArgumentOutOfRangeException("Description must be at least one character and no more than 100 characters");
            }
        }

        public float UnitPrice
        {
            get
            {
                return unitPrice;
            }

            set
            {
                if (value >= 0)
                    unitPrice = value;
                else
                    throw new ArgumentOutOfRangeException("Unit Price cannot be negative");
            }
        }

        public int OnHandQuantity
        {
            get
            {
                return onHandQuantity;
            }

            set
            {
                if (value >= 0)
                    onHandQuantity = value;
                else
                    throw new ArgumentOutOfRangeException("On Hand Quantity cannot be negative");
            }
        }

        public override string ToString()
        {
            return $"Product Code: {ProductCode}\nDescription: {Description}\nUnit Price: {UnitPrice:C2}\nOn Hand Quantity: {OnHandQuantity}";
        }
    }
}
