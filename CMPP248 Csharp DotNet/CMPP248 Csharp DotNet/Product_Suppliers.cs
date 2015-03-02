/*Coded By: Anushka Kaushalya De Silva  000680968*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Summary description for Package
/// </summary>
/// 

namespace CMPP248_Csharp_DotNet
{
    //Creating Product_Supplier Object
    public class Product_Suppliers
    {
        //Initialize Default Constructor
        public Product_Suppliers() { }

        //Define Varibale Access Methods
        public int ProductSuppliersID { get; set; }
        public int ProductID { get; set; }
        public int SupplierID { get; set; }
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
    }
}
