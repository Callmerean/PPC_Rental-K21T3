//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PPC_Rental.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ABOUT
    {
        public int ID { get; set; }
        public string AboutImage { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> Update_date { get; set; }
        public Nullable<int> Sale_ID { get; set; }
    
        public virtual USER USER { get; set; }
    }
}