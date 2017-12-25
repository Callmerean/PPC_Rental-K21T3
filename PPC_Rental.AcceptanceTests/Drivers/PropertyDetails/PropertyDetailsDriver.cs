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
                        Avatar = row["Avatar"],
                        Images = row["Images"],
                        Content = row["Content"],
                        PropertyType_ID = db.PROPERTY_TYPE.ToList().FirstOrDefault(d => d.CodeType == row["PropertyType"]).ID,
                        Street_ID = db.STREETs.ToList().FirstOrDefault(x => x.StreetName == row["Street"]).ID,
                        Ward_ID = db.WARDs.ToList().FirstOrDefault(x => x.WardName ==row["Ward"]).ID,
                        District_ID = db.DISTRICTs.ToList().FirstOrDefault(x => x.DistrictName == row["District"]).ID,
                        Price = int.Parse(row["Price"]),
                        UnitPrice = row["UnitPrice"],
                        Area = row["Area"],
                        BedRoom = int.Parse(row["BedRoom"]),
                        BathRoom = int.Parse(row["BathRoom"]),
                        PackingPlace = int.Parse(row["ParkingPlace"]),
                        UserID = db.USERs.ToList().FirstOrDefault(x => x.Email == row["Email"]).ID,
                        Created_at = DateTime.Parse(row["Created_at"]),
                        Create_post = DateTime.Parse(row["Created_post"]),
                        Status_ID = db.PROJECT_STATUS.ToList().FirstOrDefault(x => x.Status_Name == row["Status"]).ID,
                        Note = row["Note"],
                        Updated_at = DateTime.Parse(row["Update_at"]),
                        Sale_ID = int.Parse(row["Sale_ID"])
                           
                    };

                    _context.ReferenceProperties.Add(
                            Properties.Header.Contains("Id") ? row["Id"] :property.PropertyName ,
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
                b => b.PropertyName == expectedPropertyDetails["PropertyName"]);
                
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
