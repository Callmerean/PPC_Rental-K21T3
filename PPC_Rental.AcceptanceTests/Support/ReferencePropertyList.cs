using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPC_Rental.Models;
using FluentAssertions;

namespace PPC_Rental.AcceptanceTests.Support
{
    public class ReferencePropertyList: Dictionary<string, PROPERTY>
    {
        public PROPERTY GetById(string PropertyId) 
            => this[PropertyId.Trim()].Should().NotBeNull()
                                      .And.Subject.Should().BeOfType<PROPERTY>().Which;
    }
}
