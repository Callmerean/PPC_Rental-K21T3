using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using PPC_Rental.AcceptanceTests.Drivers.PropertyDetails;

namespace PPC_Rental.AcceptanceTests.StepDefinitions
{
    [Binding, Scope(Tag ="automated")]
    public class UC03_ViewDetailOfProjectSteps
    {

        private readonly PropertyDetailsDriver _propertyDriver;
        public UC03_ViewDetailOfProjectSteps(PropertyDetailsDriver driver)
        {
            _propertyDriver = driver;
        }
        [Given(@"the following properties")]
        public void GivenTheFollowingProperties(Table table)
        {
            _propertyDriver.InsertPropertyToDB(table);
        }
        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOf(string p0)
        {
            _propertyDriver.OpenPropertyIdDetails(p0);
        }


        [Then(@"the property details should show")]
        public void ThenThePropertyDetailsShouldShow(Table table)
        {
            _propertyDriver.ShowPropertyDetails(table);
        }

    }
        
 }
