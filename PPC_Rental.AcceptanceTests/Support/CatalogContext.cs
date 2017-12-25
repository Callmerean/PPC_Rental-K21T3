using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPC_Rental.AcceptanceTests.Support
{
    public class CatalogContext
    {
        public CatalogContext()
        {
            ReferenceProperties = new ReferencePropertyList();
        }

        public ReferencePropertyList ReferenceProperties { get; set; }

    }
}
