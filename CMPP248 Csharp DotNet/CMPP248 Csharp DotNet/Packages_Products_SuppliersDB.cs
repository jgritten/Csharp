/*Coded by: Jasmeen Kathuria*/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//This class defines Packages_Products_Supplier's Functionalies, such as Add Item, Update Item and Delete Item
namespace CMPP248_Csharp_DotNet
{
    class Packages_Products_SuppliersDB
    {
        //This is the function of Add Item to Database
        public static string AddItem(Packages_Products_Suppliers package_product_supplier)
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();

            string insertStatement =
                "INSERT INTO Packages_Products_Suppliers " +
                "(PackageId, ProductSupplierId) " +
                "VALUES (@PackageId, @ProductSupplierId)";
            SqlCommand insertCommand =
                new SqlCommand(insertStatement, connection);
            //insertCommand.Parameters.AddWithValue("@PackageId", package.PackageId);
            insertCommand.Parameters.AddWithValue("@PackageId", package_product_supplier.PackageId);
            insertCommand.Parameters.AddWithValue("@ProductSupplierId", package_product_supplier.ProductSupplierId);
            try
            {
                connection.Open();
                insertCommand.ExecuteNonQuery();
                string pkgID = package_product_supplier.PackageId.ToString();
                return pkgID;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
