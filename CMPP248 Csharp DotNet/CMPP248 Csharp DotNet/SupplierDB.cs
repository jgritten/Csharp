/*Coded By: Justin Gritten 000684146*/
// Suppliers Database Get, Set , Add and Modify Methods

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
    public static class SupplierDB
    {
        // Retrieve Supplier from Database
        public static List<Supplier> GetSuppliers()
        {
            // Sql Connections 
            List<Supplier> suppliers = new List<Supplier>();
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement = "SELECT * FROM Suppliers";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            // try and catch statements
            try 
	        {
	            connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
              // if else statements 
                while (reader.Read())
	            {
                    Supplier supplier = new Supplier();
                    supplier.SupplierID = Convert.ToInt32(reader["SupplierID"]);
                    supplier.SupplierName = reader["SupName"].ToString();
                    suppliers.Add(supplier);
	            }
		            // ending if else statements 
	        }
	        catch (Exception ex)
	        {
                throw ex;
	        }
                // finally code
            finally
            {
                connection.Close(); // closing the connection
            }
            return suppliers;
        }

        public static Supplier GetSupplierById(int supplierId)
        {
            Supplier supplier = new Supplier();
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement = "SELECT * FROM SUPPLIERS WHERE SupplierId = @SupplierId";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@SupplierId", supplierId);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                while (reader.Read())
                {
                    supplier.SupplierID = (int)reader["SupplierId"];
                    supplier.SupplierName = reader["SupName"].ToString();
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
            return supplier;
        }

        public static List<Supplier> GetSupplierByName()
        {
            // Sql Connections 
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement = "SELECT  SupplierId, SupName FROM Suppliers";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            List<Supplier> supplierNameList = new List<Supplier>();
            // try and catch statements
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                // if else statements 
                while (reader.Read())
                {
                    Supplier supplierList = new Supplier();
                    supplierList.SupplierName = reader["SupplierId"].ToString();
                    supplierList.SupplierName = reader["SupName"].ToString();
                    supplierNameList.Add(supplierList);
                }

                // ending if else statements 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // finally code
            finally
            {
                connection.Close(); // closing the connection
            }
            return supplierNameList;
        }


        // Add supplier to Database
        public static string AddSupplier(Supplier supplier)
        {
            // supplier sql connection
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string insertStatement = "INSERT INTO Suppliers (SupplierID, SupName) VALUES (@SupplierID, @SupName)";
            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
            insertCommand.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);
            insertCommand.Parameters.AddWithValue("@SupName", supplier.SupplierName);
            // try and catch statements 
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string supplierID = supplier.SupplierID.ToString();
                return supplierID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close(); // closing the connection 
            }
            // ending try and catch statements 
        }

        // Update supplier on Database
        public static bool UpdateSupplier(Supplier oldSupplier, Supplier newSupplier)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string updateStatement = "UPDATE Suppliers SET SupplierID = @NewSupplierID, SupName = @NewSupName " +
                                            "WHERE SupplierID = @OldSupplierID AND SupName = @OldSupName";
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@NewSupplierID", newSupplier.SupplierID);
            updateCommand.Parameters.AddWithValue("@NewSupName", newSupplier.SupplierName);
            updateCommand.Parameters.AddWithValue("@OldSupplierID", oldSupplier.SupplierID);
            updateCommand.Parameters.AddWithValue("@OldSupName", oldSupplier.SupplierName);
           // try catch statements
            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
                // if else statements
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                // ending if else statements 
            }
            catch (SqlException ex)
            {
                throw ex;
            }
                // finally statement
            finally
            {
                connection.Close();// closing connection 
            }
        }

        // Delete Supplier from Database
        public static bool DeleteSupplier(Supplier supplier)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string deleteStatement = "DELETE FROM Suppliers WHERE SupplierID = @SupplierID";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);
            // try catch statements 
            try
            {
                connection.Open();
                int count = deleteCommand.ExecuteNonQuery();
                // if else statements 
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                // ending if else statements
            }
            catch (SqlException ex)
            {
                throw ex;
            }
                // finally code
            finally
            {
                connection.Close(); // closing connection 
            }
        }
    }
}
