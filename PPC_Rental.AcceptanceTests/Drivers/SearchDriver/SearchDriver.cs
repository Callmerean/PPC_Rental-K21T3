using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using PPC_Rental.Controllers;
using PPC_Rental.Models;
using PPC_Rental.AcceptanceTests.Support;
using PPC_Rental.AcceptanceTests.Common;
using TechTalk.SpecFlow;
using PPC_Rental.AcceptanceTests.Drivers.Search;

namespace PPC_Rental.AcceptanceTests.Drivers.Search
{
    public class SearchDriver
    {
        /*       private ActionResult _result;

               public SearchDriver(ActionResult result)
               {
                   _result = result;
               }
        */
        private readonly SearchResultState _state;

        public SearchDriver(SearchResultState state)
        {
            _state = state;
        }

        public void Search(int? dis, int? propertytype, int? bed, int? bath, string price)
        {
            HomeController controller = new HomeController();
            _state.ActionResult = controller.Search(dis,propertytype,bed,bath,price);
        }

        public void ShowProperty(string expectedTitlesString)
        {
            //Arrange
            var expectedTitles = from t in expectedTitlesString.Split(',')
                                 select t.Trim().Trim('\'');
            //Action
            var ShowProperty = _state.ActionResult.Model<IEnumerable<PROPERTY>>();

            //Assert
            PropertyAssertion.HomeScreenShouldShow(ShowProperty, expectedTitles);
        }

        public void ShowProperty(Table expectedProject)
        {
            //Arrange
            var expectedTitles = expectedProject.Rows.Select(r => r["Title"]);

            //Action
            var ShowProperty = _state.ActionResult.Model<IEnumerable<PROPERTY>>();

            //Assert
            PropertyAssertion.HomeScreenShouldShowInOrder(ShowProperty, expectedTitles);
        }

        internal void Search(int Dis_ID, int type_ID, int? bed, int? bath, int? price)
        {
            throw new System.NotImplementedException();
        }
    }
}