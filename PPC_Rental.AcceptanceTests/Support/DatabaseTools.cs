using PPC_Rental.Models;
using TechTalk.SpecFlow;

namespace PPC.AcceptanceTests.Support
{
    [Binding]
    public class DatabaseTools
    {
        [BeforeScenario]
        public void CleanDatabase()
        {
            using (var db = new DemoPPCRentalEntities1())
            {
                //db.OrderLines.RemoveRange(db.OrderLines);
                //db.Orders.RemoveRange(db.Orders);
                db.PROPERTY_FEATURE.RemoveRange(db.PROPERTY_FEATURE);
                db.PROPERTies.RemoveRange(db.PROPERTies);
              
                db.SaveChanges();
            }
        }
    }
}
