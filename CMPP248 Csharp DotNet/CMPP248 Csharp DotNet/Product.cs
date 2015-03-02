/*Coded By: Brian Peng 000670881*/
/*Comments Added By: Jasmeen Kathuria 000656593*/
// Product Class containing variables and their access methods 
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
   public class Product
    {
        // default constructor
       public Product() { }


       // variable access methods
       public int ProductId { get; set; }
       public string ProductName { get; set; }
    }
}
