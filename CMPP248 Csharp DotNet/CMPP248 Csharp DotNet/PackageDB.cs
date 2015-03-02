/* 
 * author: Brian Peng
 * 2015-01-21
 * This class is define the mehthod to retrieve package records from the database
 * It is used as the data source of the website
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Summary description for Package
/// </summary>
/// 

namespace CMPP248_Csharp_DotNet
{
    public static class PackageDB
    {
        public static Package GetPackageById(int packageId) 
        {
            Package package = new Package();
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string selectStatement = "SELECT * FROM Packages WHERE PackageId = @PackageId";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@PackageId", packageId);
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
                while (reader.Read())
                {
                    package.PackageId = (int)reader["PackageId"];
                    package.pkgName = reader["PkgName"].ToString();
                    package.pkgStartDate = (DateTime)reader["PkgStartDate"];
                    package.pkgEndDate = (DateTime)reader["PkgEndDate"];
                    package.pkgDesc = reader["PkgDesc"].ToString();
                    package.pkgBasePrice = Convert.ToDecimal(reader["PkgBasePrice"]);
                    package.pkgAgencyCommission = Convert.ToDecimal(reader["PkgAgencyCommission"]);
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
            return package;
        }

        public static List<Package> GetPackages()
        {
            //List<Package> packages = new List<Package>(); //store the package objects
            SqlConnection connection = TravelExpertsDB.GetConnection();  //connect to travelexperts dababase
            //construct the sql sentence
            string selectStatement =
                "SELECT * FROM Packages";
            SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
            List<Package> packages = new List<Package>();
            try
            {
                connection.Open();
                SqlDataReader reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    Package package = new Package();
                    package.PackageId = Convert.ToInt32(reader["PackageId"]);
                    package.pkgName = reader["PkgName"].ToString();
                    package.pkgStartDate = (DateTime)reader["PkgStartDate"];
                    package.pkgEndDate = (DateTime)reader["PkgEndDate"];
                    package.pkgDesc = reader["PkgDesc"].ToString();
                    package.pkgBasePrice = Convert.ToDecimal(string.Format("{0:0.00}",reader["PkgBasePrice"]));
                    package.pkgAgencyCommission = Convert.ToDecimal(string.Format("{0:0.00}", reader["PkgAgencyCommission"]));
                    packages.Add(package);
                }

                //DataTable packages = new DataTable();
                //SqlDataAdapter sda = new SqlDataAdapter();
                //sda.SelectCommand = selectCommand;
                //sda.Fill(packages);
                //BindingSource bSource = new BindingSource();
                
                //return packages;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close(); //always close the connection to the database at the end
            }
            return packages;
        }

        //Function Which Add New Product_Supplier Records
        //This use Insert SQL Statement
        //This Function has open and Close Connection with Database to run the SQL Query and Add Data into from Database
        //Finally to prevent apllication crash, it use Try-Catch Method
        //This function will auto-generate ProductID and Product_Supplier ID
        public static string AddItem(Package package)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string insertStatement =
                "INSERT INTO Packages " +
                "(PkgName, PkgStartDate, PkgEndDate, PkgDesc, PkgBasePrice, PkgAgencyCommission) " +
                "VALUES (@PkgName, @PkgStartDate, @PkgEndDate, @PkgDesc, @PkgBasePrice, @PkgAgencyCommission)";
            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            //insertCommand.Parameters.AddWithValue("@PackageId", package.PackageId);
            insertCommand.Parameters.AddWithValue("@PkgName", package.pkgName);
            insertCommand.Parameters.AddWithValue("@PkgDesc", package.pkgDesc);
            insertCommand.Parameters.AddWithValue("@PkgStartDate", package.pkgStartDate);
            insertCommand.Parameters.AddWithValue("@PkgEndDate", package.pkgEndDate);
            insertCommand.Parameters.AddWithValue("@PkgBasePrice", package.pkgBasePrice);
            insertCommand.Parameters.AddWithValue("@PkgAgencyCommission", package.pkgAgencyCommission);
            
           try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string selectStatement =
                    "SELECT IDENT_CURRENT('Packages') FROM Packages";
                SqlCommand selectCommand =
                    new SqlCommand(selectStatement, connection);
                int packageID = Convert.ToInt32(selectCommand.ExecuteScalar());
                return packageID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Update(Package oldPackage, Package newPackage)
        {

            SqlConnection connection = TravelExpertsDB.GetConnection();
            string updateStatement =
                "UPDATE Packages SET " +
                "PkgName = @NewPkgName, " +
                "PkgStartDate = @NewStartDate, " +
                "PkgEndDate = @NewEndDate, " +
                "PkgDesc = @NewDesc, " +
                "PkgBasePrice = @NewBasePrice, " +
                "PkgAgencyCommission = @NewAgencyCommission " +
                "WHERE PkgName = @OldPkgName";
            SqlCommand updateCommand =
                new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@NewPkgName", newPackage.pkgName);
            updateCommand.Parameters.AddWithValue("@NewStartDate", newPackage.pkgStartDate);
            updateCommand.Parameters.AddWithValue("@NewEndDate", newPackage.pkgEndDate);
            updateCommand.Parameters.AddWithValue("@NewDesc", newPackage.pkgDesc);
            updateCommand.Parameters.AddWithValue("@NewBasePrice", newPackage.pkgBasePrice);
            updateCommand.Parameters.AddWithValue("@NewAgencyCommission", newPackage.pkgAgencyCommission);
            updateCommand.Parameters.AddWithValue("@OldPkgName", oldPackage.pkgName);


    //    updateCommand.Parameters.AddWithValue("@OldStartDate", oldPackage.PkgStartDate);
    //    updateCommand.Parameters.AddWithValue("@OldEndDate", oldPackage.PkgEndDate);
    //    updateCommand.Parameters.AddWithValue("@OldDesc", oldPackage.PkgDesc);
    //    updateCommand.Parameters.AddWithValue("@OldBasePrice", oldPackage.PkgBasePrice);
    //    updateCommand.Parameters.AddWithValue("@OldAgencyCommission", oldPackage.PkgAgencyCommission);

            try
            {
                connection.Open();
                int count = updateCommand.ExecuteNonQuery();
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
                connection.Close();
            }
        }

        public static bool Delete(Package package)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            string deleteStatement = "Delete FROM Packages WHERE PackageId = @PackageId";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@PackageId", package.PackageId);
            try
            {
                connection.Open();
                int num = deleteCommand.ExecuteNonQuery();
                if (num > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException sex) { throw sex; }
            catch (Exception ex) { throw ex; }
        }
    }
}