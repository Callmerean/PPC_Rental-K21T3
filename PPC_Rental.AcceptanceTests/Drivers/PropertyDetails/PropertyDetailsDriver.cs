using System;
using System.Linq;
using PPC_Rental.Controllers;
using FluentAssertions;
using TechTalk.SpecFlow;
using PPC_Rental.Models;
using System.Web.Mvc;
using PPC_Rental.AcceptanceTests.Support;
using System.Collections.Generic;

namespace PPC_Rental.AcceptanceTests.Drivers.PropertyDetails
{

    public class PropertyDetailsDriver
    {
        private const int PropertyDefaultPrice = 10;
        private readonly PropertyContext _context;
        private ActionResult _result;

        public PropertyDetailsDriver(PropertyContext context)
        {
            _context = context;
        }

        public void InsertpropertyToDB(Table Properties)
        {
            using (var db = new DemoPPCRentalEntities1())
            {
                foreach (var row in Properties.Rows)
                {
                    var property = new PROPERTY
                    {
                        PropertyName = row["PropertyName"],
                        Area = row["Area"],
                        Price = Properties.Header.Contains("Price")
                            ? Convert.ToInt32(row["Price"])
                            : PropertyDefaultPrice
                    };

                    _context.ReferenceProperties.Add(
                            Properties.Header.Contains("ID") ? row["ID"] : property.Area,
                            property);

                    db.PROPERTies.Add(property);
                }

                db.SaveChanges();
            }
        }

        public void ShowpropertyDetails(Table shownPropertyDetails)
        {
            //Arrange
            var expectedPropertyDetails = shownPropertyDetails.Rows.Single();

            //Act
            var actualPropertyDetails = _result.Model<PROPERTY>();

            //Assert
            actualPropertyDetails.Should().Match<PROPERTY>(
                b => b.Area == expectedPropertyDetails["Area"]
                && b.PropertyName == expectedPropertyDetails["PropertyName"]
                && b.Price == int.Parse(expectedPropertyDetails["Price"]));
        }

        public void OpenpropertyDetails(string propertyId)
        {
            var property = _context.ReferenceProperties.GetById(propertyId);
            using (var controller = new HomeController())
            {
                _result = controller.Details(property.ID);
            }
        }
    }
}
