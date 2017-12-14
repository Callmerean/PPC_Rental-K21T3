using System;
using TechTalk.SpecFlow;
using PPC_Rental.AcceptanceTests.Drivers.PropertyDetails;


namespace PPC_Rental.AcceptanceTests.StepDefinitions
{
    [Binding]
   public class UC003_ViewDetailSteps
    {
        private readonly PropertyDetailsDriver _propertyDriver;

        public UC003_ViewDetailSteps(PropertyDetailsDriver driver)
        {
            _propertyDriver = driver;
        }

        [Given(@"the following propertys")]
        public void GivenTheFollowingpropertys(Table givenpropertys)
        {
            _propertyDriver.InsertpropertyToDB(givenpropertys);
        }

        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOf(string propertyId)
        {
            _propertyDriver.OpenpropertyDetails(propertyId);
        }

        [Then(@"the property details should show")]
        public void ThenThepropertyDetailsShouldShow(Table shownpropertyDetails)
        {
            _propertyDriver.ShowpropertyDetails(shownpropertyDetails);
        }
    }


}
