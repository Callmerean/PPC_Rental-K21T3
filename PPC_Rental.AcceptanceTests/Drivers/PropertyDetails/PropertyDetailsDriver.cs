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
        DemoPPCRentalEntities1 db = new DemoPPCRentalEntities1();
        DemoPPCRentalEntities1 ab = new DemoPPCRentalEntities1();
        private readonly CatalogContext _context;
        private ActionResult _result;

        public PropertyDetailsDriver(CatalogContext context)
        {
            _context = context;
        }

        public void CreateProperty(Table Property)
        {
            using (ab)
            {

                foreach (var row in Property.Rows)
                {

                    string propertyID = row["Property Type"];
                    string userID = row["Owner"];
                    string wardID = row["Ward"];
                    string districtID = row["District"];
                    string streetID = row["Street"];
                    string statusID = row["Status"];
                    var property = new PROPERTY
                    {

                        PropertyName = row["PropertyName"],
                        Price = int.Parse(row["Price"]),

                        Avatar = row["Avatar"],
                        Images = row["Images"],
                        UnitPrice = row["UnitPrice"],
                        Ward_ID = ab.WARDs.FirstOrDefault(d => d.WardName == wardID).ID,
                        UserID = ab.USERs.FirstOrDefault(d => d.Email == userID).ID,
                        Street_ID = ab.STREETs.FirstOrDefault(d => d.StreetName == streetID).ID,
                        District_ID = ab.DISTRICTs.FirstOrDefault(d => d.DistrictName == districtID).ID,
                        Area = row["Area"],
                        BedRoom = int.Parse(row["BedRoom"]),
                        BathRoom = int.Parse(row["BathRoom"]),
                        PackingPlace = int.Parse(row["ParkingPlace"]),
                        Created_at = DateTime.Parse(row["Created_at"]),
                        Create_post = DateTime.Parse(row["Created_post"]),
                        Note = row["Note"],
                        Updated_at = DateTime.Parse(row["Updated_at"]),
                        Status_ID = ab.PROJECT_STATUS.FirstOrDefault(d => d.Status_Name == statusID).ID,
                        //Property_ID = row["Property_ID"],
                        Content = row["Content"],
                        PropertyType_ID = ab.PROPERTY_TYPE.FirstOrDefault(d => d.CodeType == propertyID).ID,


                    };

                    _context.ReferenceProperties.Add(
                            Property.Header.Contains("ID") ? row["ID"] : property.PropertyName,
                            property);

                    ab.PROPERTies.Add(property);
                }
                ab.SaveChanges();
            }
        }
        public void InsertPropertyToDB(Table Property)
        {

            using (db)
            {

                foreach (var row in Property.Rows)
                {

                    string propertyID = row["Property Type"];
                    string userID = row["Owner"];
                    string wardID = row["Ward"];
                    string districtID = row["District"];
                    string streetID = row["Street"];
                    string statusID = row["Status"];
                    var property = new PROPERTY
                    {

                        PropertyName = row["PropertyName"],
                        Price = int.Parse(row["Price"]),

                        Avatar = row["Avatar"],
                        Images = row["Images"],
                        UnitPrice = row["UnitPrice"],
                        Ward_ID = db.WARDs.FirstOrDefault(d => d.WardName == wardID).ID,
                        UserID = db.USERs.FirstOrDefault(d => d.Email == userID).ID,
                        Street_ID = db.STREETs.FirstOrDefault(d => d.StreetName == streetID).ID,
                        District_ID = db.DISTRICTs.FirstOrDefault(d => d.DistrictName == districtID).ID,
                        Area = row["Area"],
                        BedRoom = int.Parse(row["BedRoom"]),
                        BathRoom = int.Parse(row["BathRoom"]),
                        PackingPlace = int.Parse(row["ParkingPlace"]),
                        Created_at = DateTime.Parse(row["Created_at"]),
                        Create_post = DateTime.Parse(row["Created_post"]),
                        Note = row["Note"],
                        Updated_at = DateTime.Parse(row["Updated_at"]),
                        Status_ID = db.PROJECT_STATUS.FirstOrDefault(d => d.Status_Name == statusID).ID,
                        //Property_ID = row["Property_ID"],
                        Content = row["Content"],
                        PropertyType_ID = db.PROPERTY_TYPE.FirstOrDefault(d => d.CodeType == propertyID).ID,


                    };

                    _context.ReferenceProperties.Add(
                            Property.Header.Contains("ID") ? row["ID"] : property.PropertyName,
                            property);

                    db.PROPERTies.Add(property);
                }

                //db.Entry(Property).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public void ShowPropertyDetails(Table shownPropertyDetails)
        {
            //Arrange
            DemoPPCRentalEntities1 dbt = new DemoPPCRentalEntities1();
            var expectedPropertyDetails = shownPropertyDetails.Rows.Single();
            string exPropertyName = expectedPropertyDetails["PropertyName"];
            string exAvatar = expectedPropertyDetails["Avatar"];
            string exOwner = expectedPropertyDetails["Owner"];
            var userID = dbt.USERs.ToList().FirstOrDefault(d => d.Email == exOwner).ID;
            string exContent = expectedPropertyDetails["Content"];
            string exPrice = expectedPropertyDetails["Price"];
            //Act
            var actualPropertyDetails = _result.Model<PROPERTY>();

            //Assert
            actualPropertyDetails.Should().Match<PROPERTY>(
                b => b.PropertyName == exPropertyName
                && b.Avatar == exAvatar
                && b.UserID == userID
                && b.Content == exContent
                && b.Price == int.Parse(exPrice));
        }

        public void OpenPropertyIdDetails(string propertyId)
        {
            var property = _context.ReferenceProperties.GetById(propertyId);
            using (var controller = new HomeController())
            {
                _result = controller.Details(property.ID);
            }
        }
    }
}
