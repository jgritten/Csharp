/* 
 * author: Brian Peng
 * 2015-01-21
 * This class is to define package object
 */

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
    public class Package
    {
	    public Package()
	    {
		    //
		    // TODO: Add constructor logic here
		    //
	    }
        public int PackageId { get; set; }
        public string pkgName { get; set; }
        public DateTime pkgStartDate { get; set; }
        public DateTime pkgEndDate { get; set; }
        public string pkgDesc  { get; set; }
        public decimal pkgBasePrice { get; set; }
        public decimal pkgAgencyCommission { get; set; }
    }
}