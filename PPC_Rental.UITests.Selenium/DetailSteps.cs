using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using PPC_Rental.AcceptanceTests.Common;
using PPC_Rental.UITests.Selenium.Support;
using PPC_Rental.Models;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Firefox;

namespace PPC_Rental.UITests.Selenium
{
    public class DetailSteps
    {

        [Binding, Scope(Tag = "web")]
        public class SearchSteps : SeleniumStepsBase
        {
            private IWebDriver driver = new FirefoxDriver();
            [Given(@"the following propertys")]
            public void GivenTheFollowingpropertys(Table givenpropertys)
            {
                driver.Navigate().GoToUrl("http://localhost:61656/Home/Index");
                Thread.Sleep(1000);
            }

            [When(@"I open the details of '(.*)'")]
            public void WhenIOpenTheDetailsOf(string propertyId)
            {
                driver.Navigate().GoToUrl("http://localhost:61656/Project/Detail/2");
                Thread.Sleep(1000);
            }

            [Then(@"the property details should show")]
            public void ThenThepropertyDetailsShouldShow(Table expectedDetails)
            {
                var expectedTitles = expectedDetails.Rows.Select(r => r["PropertyName"]);
                driver.SwitchTo().DefaultContent();

                var viewdetail = from row in driver.FindElements(By.XPath("//div[contains(@id,'detail-header')]/p"))
                                 let Name = row.Text
                                 select new PROPERTY { PropertyName = Name };

                PropertyAssertion.ViewDetailProject(viewdetail, expectedTitles);


            }
        }
    }
}
