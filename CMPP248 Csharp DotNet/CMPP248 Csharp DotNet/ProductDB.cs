/*Coded By: Brian Peng 000670881*/
/*Comments Added By: Jasmeen Kathuria 000656593*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Summary description for Package
/// </summary>
/// 

namespace CMPP248_Csharp_DotNet
{
    public static class ProductDB
    {

        public static Product GetProductById(int productId)
        {
            Product product = new Product();
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement = "SELECT * FROM Products WHERE ProductId = @ProductId";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductId", productId);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                while (reader.Read())
                {
                    product.ProductId = (int)reader["ProductId"];
                    product.ProductName = reader["ProdName"].ToString();
                }
            }
            catch (SqlException sex)
            {
                throw sex;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return product;
        }

        // Retrieve Product from Database accoring to product id 
        public static List<Product> GetProducts()
        {
            // Product Sql Connection
            List<Product> products = new List<Product>();
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement = "SELECT * FROM Products";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            // try and catch statements
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                // if else statements 
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductId = (int)reader["ProductId"];
                    product.ProductName = reader["ProdName"].ToString();
                    products.Add(product);
                    
                    //return products; // returning product 
                }
                // ending if else statements 
            }
            catch (SqlException ex)
            {
                throw ex;
            }
                //finally 
            finally
            {
                connection.Close(); // closing connection 
            }
            return products;
        }

        // retrieve Product from Database according to Product Name
        public static List<Product> GetProductsByName()
        {
            // Product Sql Connection
            List<Product> products = new List<Product>();
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement = "SELECT * FROM Products";
            SqlCommand selectCommand =
                new SqlCommand(selectStatement, connection);
            List<Product> productNameList = new List<Product>();
            // try and catch statements
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                // if else statements 
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductId = (int)reader["ProductId"];
                    product.ProductName = reader["ProdName"].ToString();
                    products.Add(product);

                    //return products; // returning product 
                }
                // ending if else statements 
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            //finally 
            finally
            {
                connection.Close(); // closing connection 
            }
            return products;
        }

        // Add Product to Database
        public static int AddProduct(Product product)
        {
            // Sql Connections
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string insertStatement =
                "INSERT INTO Products " +
                "(ProdName) " +
                "VALUES (@ProdName)";
            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue(
                "@ProdName", product.ProductName);
            //insertCommand.Parameters.AddWithValue("@ProductID", product.ProductId);
            // try catch statements 
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT IDENT_CURRENT('Products') FROM Products";
                SqlCommand selectCommand =
                    new SqlCommand(selectStatement, connection);
                int prodId = Convert.ToInt32(selectCommand.ExecuteScalar());
                return prodId;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
                // finally
            finally
            {
                connection.Close(); // closing Connection
            }
        }

        // Update Product on Database
        public static bool UpdateProduct(Product oldProduct, Product newProduct)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string updateStatement =
                "UPDATE Products SET " +
                "ProdName = @NewProdName " +
                "WHERE ProdName = @OldProdName";
            SqlCommand updateCommand =
                new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue(
                "@NewProdName", newProduct.ProductName);          
            updateCommand.Parameters.AddWithValue(
                "@OldProdName", oldProduct.ProductName);
            // try catch statements 
            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
                // if else statements 
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close(); // closing connection 
            }
        }

        // Delete Product from Database
        public static bool DeleteProduct(Product product)
        {
            // sql connections 
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string deleteStatement =
                "DELETE FROM Products " +
                "WHERE ProdName = @NewProdName";
            SqlCommand deleteCommand =
                new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue(
                "@NewProdName", product.ProductName);
           // try catch statements 
            try
            {
                connection.Open();
                int count = deleteCommand.ExecuteNonQuery();
                // if else statements 
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
                // finally
            finally
            {
                connection.Close(); // closing connection 
            }
        }
    }
}
