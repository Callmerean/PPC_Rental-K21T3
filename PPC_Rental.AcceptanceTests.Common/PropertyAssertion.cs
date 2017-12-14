using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPC_Rental.Models;
using FluentAssertions;

namespace PPC_Rental.AcceptanceTests.Common
{
   public class PropertyAssertion
    {
        public static void FoundPROPERTYsShouldMatchPropertyNames(IEnumerable<PROPERTY> foundPROPERTYs, IEnumerable<string> expectedPropertyNames)
        {
            foundPROPERTYs.Select(b => b.PropertyName).Should().BeEquivalentTo(expectedPropertyNames);
        }

        public static void FoundPROPERTYsShouldMatchPropertyNamesInOrder(IEnumerable<PROPERTY> foundPROPERTYs, IEnumerable<string> expectedPropertyNames)
        {
            foundPROPERTYs.Select(b => b.PropertyName).Should().Equal(expectedPropertyNames);
        }

        public static void HomeScreenShouldShow(IEnumerable<PROPERTY> shownPROPERTYs, string expectedPropertyName)
        {
            shownPROPERTYs.Select(b => b.PropertyName).Should().Contain(expectedPropertyName);
        }

        public static void HomeScreenShouldShow(IEnumerable<PROPERTY> shownPROPERTYs, IEnumerable<string> expectedPropertyNames)
        {
            shownPROPERTYs.Select(b => b.PropertyName).Should().BeEquivalentTo(expectedPropertyNames);
        }

        public static void HomeScreenShouldShowInOrder(IEnumerable<PROPERTY> shownPROPERTYs, IEnumerable<string> expectedPropertyNames)
        {
            shownPROPERTYs.Select(b => b.PropertyName).Should().Equal(expectedPropertyNames);
        }
        public static void ViewDetailProject(IEnumerable<PROPERTY> viewdetail, IEnumerable<string> expectedTitles)
        {
            viewdetail.Select(x => x.PropertyName).Should().Contain(expectedTitles);
        }
    }
}
