using System;
using System.Collections.Generic;
using System.Text;

namespace MMABooksBusinessClasses
{
    public class Product
    {
        public Product() { }

        public Product(int code, string description, float price, int quantity)
        {
            ProductCode = code;
            Description = description;
            UnitPrice = price;
            OnHandQuantity = quantity;
        }

        private int productCode;
        private string description;
        private float unitPrice;
        private int onHandQuantity;

        public int ProductCode
        {
            get
            {
                return productCode;
            }

            set
            {
                if (value > 0)
                    productCode = value;
                else
                    throw new ArgumentOutOfRangeException("Product Code must be a positive integer");
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
                if (value.Trim().Length > 0 && value.Trim().Length <= 100)
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