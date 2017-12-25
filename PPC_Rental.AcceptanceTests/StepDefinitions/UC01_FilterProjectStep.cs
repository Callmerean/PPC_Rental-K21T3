using System;
using TechTalk.SpecFlow;
using PPC_Rental.Models;
using System.Linq;
using PPC_Rental.AcceptanceTests.Drivers.Search;



namespace PPC_Rental.AcceptanceTests.StepDefinitions
{
    [Binding, Scope(Tag = "automated")]
    public class UC01_FilterProjectStep
    {
        private readonly SearchDriver _searchDriver;
        DemoPPCRentalEntities1 db = new DemoPPCRentalEntities1();
        private string expectedTitles;

        public UC01_FilterProjectStep(SearchDriver driver)
        {
            _searchDriver = driver;

        }

        [When(@"I search for projects by the phrase '(.*)','(.*)','(.*)','(.*)','(.*)'")]
        public void WhenISearchForProjectsByThePhrase(string dis, string propertytype, int bed, int bath, string price)
        {
            int type_ID = db.PROPERTY_TYPE.ToList().FirstOrDefault(x => x.CodeType == propertytype).ID;
            int Dis_ID = db.DISTRICTs.ToList().FirstOrDefault(x => x.DistrictName == dis).ID;
            _searchDriver.Search(Dis_ID, type_ID, bed, bath, price);
        }

        [Then(@"project should display project with projectname follow '(.*)'")]
        public void ThenProjectShouldDisplayProjectWithProjectnameFollow(string expectedTitles)
        {
            _searchDriver.ShowProperty(expectedTitles);
        }

   



}

}