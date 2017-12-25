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

        //[Binding, Scope(Tag = "web")]
        //public class SearchSteps : SeleniumStepsBase
        //{
           
        //    [Given(@"the following propertys")]
        //    public void GivenTheFollowingpropertys(Table givenpropertys)
        //    {
                

        //        //Input value to search for
        //        Browser.ClickLinkByHref("http://localhost:4675/Home/Index");
                
        //    }

        //    [When(@"I open the details of '(.*)'")]
        //    public void WhenIOpenTheDetailsOf(string propertyId)
        //    {
        //        Browser.ClickLinkByHref("http://localhost:4675/Home/Details/16");
        //    }

        //    [Then(@"the property details should show")]
        //    public void ThenThepropertyDetailsShouldShow(Table expectedDetails)
        //    {
        //        var expectedTitles = expectedDetails.Rows.Select(r => r["PropertyName"]);
        //        Browser.SwitchTo().DefaultContent();

        //        var viewdetail = from row in Browser.FindElements(By.XPath("//div[contains(@id,'detail-header')]/p"))
        //                         let Name = row.Text
        //                         select new PROPERTY { PropertyName = Name };

        //        PropertyAssertion.ViewDetailProject(viewdetail, expectedTitles);


        //    }
        //}
    }
}
