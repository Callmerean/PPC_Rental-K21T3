using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace PPC_Rental.Models
{
    public class IndexViewModel
    {
        public List<PROPERTY> allProperties { get; set; }
        public List<DISTRICT> allDistricts { get; set; }
    }
   
}