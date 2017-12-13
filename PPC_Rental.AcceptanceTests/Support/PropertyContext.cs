using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC_Rental.AcceptanceTests.Support
{
    public class PropertyContext
    {
        public PropertyContext()
        {
           ReferenceProperties  = new ReferencePropertyList();
        }

        public ReferencePropertyList ReferenceProperties { get; set; }
    }
}
