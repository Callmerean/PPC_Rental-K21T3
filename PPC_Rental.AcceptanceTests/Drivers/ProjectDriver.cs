using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PPC_Rental.Models;
using PPC_Rental.Controllers;
using TechTalk.SpecFlow;
using PPC_Rental.AcceptanceTests.Common;
using PPC_Rental.AcceptanceTests.Support;
using PPC_Rental.AcceptanceTests;
using PPC_Rental.AcceptanceTests.Drivers;
using FluentAssertions;
using PPC_Rental.AcceptanceTests.Drivers.Search;
using PPC_Rental.Areas.Admin.Controllers;

namespace PPC_Rental.AcceptanceTests.Drivers
{
    public class ProjectDriver
    {
        private readonly SearchResultState _context;
        //private ActionResult _result;

        public ProjectDriver(SearchResultState context)
        {
            _context = context;
        }

        public void InsertProjecttoDB(Table givenProjects)
        {
            using (var db = new DemoPPCRentalEntities1())
            {
                foreach (var row in givenProjects.Rows)
                {
                    var property = new PROPERTY
                    {
                        PropertyName = row["PropertyName"],
                        PropertyType_ID = db.PROPERTY_TYPE.ToList().FirstOrDefault(x=>x.CodeType==row["PropertyType"]).ID,
                        //Status_ID = db.PROJECT_STATUS.ToList().FirstOrDefault(x => x.Status_Name == row["Status"]).ID,
                        District_ID = db.DISTRICTs.ToList().FirstOrDefault(x => x.DistrictName == row["District"]).ID,
                      //  Street_ID = db.STREETs.ToList().FirstOrDefault(x => x.StreetName == row["Street"]).ID,
                       // Content = row["Content"],
                        //UserID = db.USERs.ToList().FirstOrDefault(x => x.FullName == row["Agency"]).ID,
                        //Sale_ID = db.USERs.ToList().FirstOrDefault(x => x.FullName == row["Sale"]).ID,
                        Price = int.Parse(row["Price"]),
                        BedRoom =int.Parse(row["BedRoom"]),
                        BathRoom = int.Parse(row["BathRoom"])

                    };

                    //_context.ReferenceBooks.Add(
                    //        givenProjects.Header.Contains("ID") ? row["ID"] : row["PropertyName"],
                    //        property);

                    db.PROPERTies.Add(property);
                }

                db.SaveChanges();
            }
        }


        public void Login(string email, string pass)
        {
            using (var controller = new ClientController())
            {
                _context.ActionResult = controller.Login(email, pass);
            }
        }


        //public void ShowList(Table expectednameList)
        //{
        //    //Arrange
        //    var expected = expectednameList.Rows.Select(x => x["PropertyName"]);

        //    var ShownName = _result.ActionResult.Model<IEnumerable<PROPERTY>>();

        //    //Assert
        //    PropertyAssertions.HomeScreenShouldShow(ShownName, expectednameList);
        //}
    }
}
