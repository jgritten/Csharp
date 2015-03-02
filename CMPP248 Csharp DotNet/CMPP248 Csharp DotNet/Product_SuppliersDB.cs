/*Coded By: Anushka Kaushalya De Silva  000680968*/
/*Some Parts Coded by Justin Gritten. I have marked his on those parts of the code*/

using System;
using System.Collections.Generic;
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
    class Product_SuppliersDB
    {   
        //This Part of the Code by Anushka Kaushalya De Silva and made changes by Justin Gritten

        //Function Which Retrieve Product_Supplier Records
        //This use Select SQL Statement
        //This Function has open and Close Connection with Database to run the SQL Query and Pull Data out from Database
        //Then Pulled Data, assigning to class parameters
        //Finally to prevent apllication crash, it use Try-Catch Method
        public static List<Product_Suppliers> GetProduct_Suppliers()
        {
            List<Product_Suppliers> product_suppliers = new List<Product_Suppliers>();
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement = "SELECT * FROM Products_Suppliers";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            try
            {
                connection.Open();
                SqlDataReader itemReader = selectCommand.ExecuteReader();
                while (itemReader.Read())
                {
                    Product_Suppliers productSupplier = new Product_Suppliers();
                    productSupplier.ProductSuppliersID = (int)itemReader["ProductSupplierId"];
                    productSupplier.ProductID = (int)itemReader["ProductID"];
                    productSupplier.SupplierID = (int)itemReader["SupplierID"];
                    product_suppliers.Add(productSupplier);
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
            finally
            {
                connection.Close();
            }
            return product_suppliers;
        }

        //Function which Call Supplier Name, Product Name and Product_Supplier ID

        public static List<Product_Suppliers> GetAllProduct_SupplierByNames()
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement = "SELECT p.ProdName, s.SupName, ps.ProductSupplierID " +
                                    "FROM Products_Suppliers ps, Products p, Suppliers s " +
                                    "where p.ProductId=ps.ProductId AND ps.SupplierId=s.SupplierId";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            List<Product_Suppliers> psList = new List<Product_Suppliers>();
            try
            {
                connection.Open();
                SqlDataReader itemReader = selectCommand.ExecuteReader();
                while (itemReader.Read())
                {
                    Product_Suppliers productSuppliers = new Product_Suppliers();
                    productSuppliers.ProductName = itemReader["ProdName"].ToString();
                    productSuppliers.SupplierName = itemReader["SupName"].ToString();
                    productSuppliers.ProductSuppliersID = (int)itemReader["ProductSupplierId"];
                    psList.Add(productSuppliers);
                    //return productSuppliers;

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
            finally
            {
                connection.Close();
            }

            return psList;
        }

        //This Part of the Code by Anushka Kaushalya De Silva and made changes by Justin Gritten

        //Function Which Retrieve Product_Supplier Records
        //This use Select SQL Statement
        //This Function has open and Close Connection with Database to run the SQL Query and Pull Data out from Database
        //Then Pulled Data, assigning to class parameters
        //Finally to prevent apllication crash, it use Try-Catch Method
        public static Product_Suppliers GetProduct_Supplier(int productSupplierCode)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement = "SELECT ProductSupplierID, ProductID, SupplierID "
                + "FROM Products_Suppliers "
                + "WHERE ProductSupplierId=@ProductSupplierId";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@ProductSupplierId", productSupplierCode);
            try
            {
                connection.Open();
                SqlDataReader itemReader = selectCommand.ExecuteReader(System.Data.CommandBehavior.SingleRow);
                if (itemReader.Read())
                {
                    Product_Suppliers productSuppliers = new Product_Suppliers();
                    productSuppliers.ProductSuppliersID = (int)itemReader["ProductSupplierId"];
                    productSuppliers.ProductID = (int)itemReader["ProductID"];
                    productSuppliers.SupplierID = (int)itemReader["SupplierID"];
                    return productSuppliers;
                }
                else
                {
                    return null;
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
            finally
            {
                connection.Close();
            }
        }


        //Function Which Add New Product_Supplier Records
        //This use Insert SQL Statement
        //This Function has open and Close Connection with Database to run the SQL Query and Add Data into from Database
        //Finally to prevent apllication crash, it use Try-Catch Method
        //This function will auto-generate ProductID and Product_Supplier ID
        public static string AddItem(Product_Suppliers prodSUP)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string insertStatement =
                "INSERT INTO Products_Suppliers " +
                "(ProductId, SupplierId) " +
                "VALUES (@ProductId, @SupplierId)";
            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            //insertCommand.Parameters.AddWithValue(
            //    "@ProductSupplierID", productSupplier.ProductSuppliersID);
            insertCommand.Parameters.AddWithValue(
                "@ProductID", prodSUP.ProductID);
            insertCommand.Parameters.AddWithValue(
                "@SupplierID", prodSUP.SupplierID);

            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT IDENT_CURRENT('Products_Suppliers') FROM Products_Suppliers";
                SqlCommand selectCommand =
                    new SqlCommand(selectStatement, connection);
                int productSupplierID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return productSupplierID.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Function Which Add New Product_Supplier Records
        //This use Update SQL Statement
        //This Function has open and Close Connection with Database to run the SQL Query and Update Data into from Database
        //Finally to prevent apllication crash, it use Try-Catch Method
        public static bool UpdateItem(Product_Suppliers oldItem, Product_Suppliers newItem)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string updateStatement =
                "UPDATE Product_Suppliers SET " +
                "ProductSupplierID= @NewProductSupplierID, " +
                "ProductID= @NewProductID, " +
                "SupplierID= @NewSupplierID, " +
                "WHERE ProductSupplierID= @OldProductSupplierID " +
                "AND ProductID= @OldProductID, " +
                "AND SupplierID= @OldSupplierID, ";
            SqlCommand updateCommand =
                new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue(
                "@NewProductSupplierID", newItem.ProductSuppliersID);
            updateCommand.Parameters.AddWithValue(
                "@NewProductID", newItem.ProductID);
            updateCommand.Parameters.AddWithValue(
                "@NewSupplierID", newItem.SupplierID);
            updateCommand.Parameters.AddWithValue(
                "@OldProductSupplierID", newItem.ProductSuppliersID);
            updateCommand.Parameters.AddWithValue(
                "@OldProductID", newItem.ProductID);
            updateCommand.Parameters.AddWithValue(
                "@OldSupplierID", newItem.SupplierID);

            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else 
                    return false;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        //Function Which Delete Product_Supplier Records
        //This use Delete SQL Statement
        //This Function has open and Close Connection with Database to run the SQL Query and Update Data into from Database
        //Finally to prevent apllication crash, it use Try-Catch Method
        public static bool DeleteItem(Product_Suppliers productSuppliers)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string deleteStatment =
                "DELETE FROM Products_Suppliers " +
                "WHERE ProductId=@ProductId " +
                "AND SupplierId=@SupplierId " +
                "AND ProductSupplierID = @ProductSupplierID";
            SqlCommand deleteCommand =
                new SqlCommand(deleteStatment, connection);
            deleteCommand.Parameters.AddWithValue(
                "@ProductId", productSuppliers.ProductID);
            deleteCommand.Parameters.AddWithValue(
                "@SupplierId",productSuppliers.SupplierID);
            deleteCommand.Parameters.AddWithValue("@ProductSupplierID",productSuppliers.ProductSuppliersID);

            try
            {
                connection.Open();
                int count = deleteCommand.ExecuteNonQuery();
                if (count > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException sex)
            {
                throw sex;
            }
            catch (Exception ex)
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
