using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;
using System.Data;
using MMABooksBusinessClasses;

namespace MMABooksDBClasses
{
    public static class ProductDB
    {
        public static Product GetProduct(string productCode)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string selectStatement =
                "SELECT ProductCode, Description, UnitPrice, OnHandQuantity " +
                "FROM Products " +
                "WHERE ProductCode = @ProductCode";
            MySqlCommand selectCommand =
                new MySqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductCode", productCode);

            try
            {
                connection.Open();
                MySqlDataReader productReader =
                    selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                if (productReader.Read())
                {
                    Product product = new Product();
                    product.ProductCode = productReader["ProductCode"].ToString();
                    product.Description = productReader["Description"].ToString();
                    product.UnitPrice = Convert.ToSingle(productReader["UnitPrice"]);
                    product.OnHandQuantity = (int)productReader["OnHandQuantity"];

                    productReader.Close();
                    return product;
                }
                else
                {
                    return null;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static string AddProduct(Product product)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string insertStatement =
                "INSERT Products " +
                "(ProductCode, Description, UnitPrice, OnHandQuantity) " +
                "VALUES (@ProductCode, @Description, @UnitPrice, @OnHandQuantity)";
            MySqlCommand insertCommand =
                new MySqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            insertCommand.Parameters.AddWithValue("@Description", product.Description);
            insertCommand.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            insertCommand.Parameters.AddWithValue("@OnHandQuantity", product.OnHandQuantity);

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();

                // Retrieve the product code after insertion
                string selectStatement =
                    "SELECT ProductCode " +
                    "FROM Products " +
                    "WHERE Description = @Description " +
                    "AND UnitPrice = @UnitPrice " +
                    "AND OnHandQuantity = @OnHandQuantity";
                MySqlCommand selectCommand =
                    new MySqlCommand(selectStatement, connection);
                selectCommand.Parameters.AddWithValue("@Description", product.Description);
                selectCommand.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                selectCommand.Parameters.AddWithValue("@OnHandQuantity", product.OnHandQuantity);

                string productCode = selectCommand.ExecuteScalar()?.ToString(); // Use ToString() to handle possible null value
                return productCode;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }



        public static bool DeleteProduct(Product product)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Products " +
                "WHERE ProductCode = @ProductCode";
            MySqlCommand deleteCommand =
                new MySqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@ProductCode", product.ProductCode);

            try
            {
                connection.Open();
                int rowsAffected = deleteCommand.ExecuteNonQuery();
                return rowsAffected == 1;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool UpdateProduct(Product oldProduct, Product newProduct)
        {
            MySqlConnection connection = MMABooksDB.GetConnection();
            string updateStatement =
                "UPDATE Products SET " +
                "Description = @NewDescription, " +
                "UnitPrice = @NewUnitPrice, " +
                "OnHandQuantity = @NewOnHandQuantity " +
                "WHERE ProductCode = @OldProductCode";
            MySqlCommand updateCommand = new MySqlCommand(updateStatement, connection);

            updateCommand.Parameters.AddWithValue("@NewDescription", newProduct.Description);
            updateCommand.Parameters.AddWithValue("@NewUnitPrice", newProduct.UnitPrice);
            updateCommand.Parameters.AddWithValue("@NewOnHandQuantity", newProduct.OnHandQuantity);

            updateCommand.Parameters.AddWithValue("@OldProductCode", oldProduct.ProductCode);

            try
            {
                connection.Open();
                int rowsAffected = updateCommand.ExecuteNonQuery();
                return rowsAffected == 1;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}