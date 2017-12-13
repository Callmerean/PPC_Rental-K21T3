using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using FluentAssertions;
using PPC_Rental.Models;


namespace PPC_Rental.AcceptanceTests.StepDefinitions
{
    [Binding]
   public class UC003_ViewDetailSteps
    {
        private IWebDriver driver = new FirefoxDriver();
        [Given(@"I'm in PPC Main Page")]
        public void GivenIMInPPCMainPage()
        {
            driver.Navigate().GoToUrl("http://localhost:4675/");
            Thread.Sleep(1000);
        }

        [When(@"I click button view detail")]
        public void WhenIClickButtonViewDetail()
        {
            driver.Navigate().GoToUrl("http://localhost:4675/Home/Details/16");
            Thread.Sleep(1000);
        }

        [Then(@"I will see View Detail Of Project Page '(.*)'")]
        public void ThenIWillSeeViewDetailOfProjectPage(string expectedTitles)
        {
            var expectedResult = expectedTitles.Split(',').Select(x => x.Trim('\''));
            driver.SwitchTo().DefaultContent();

            var viewdetail = from row in driver.FindElements(By.XPath("//div[contains(@id,'detail-header')]/p"))
                             let Name = row.Text
                             select new PROPERTY { PropertyName = Name };

            AssertionDetail.ViewDetailProject(viewdetail, expectedResult);

        }
        public class AssertionDetail
        {
            public static void ViewDetailProject(IEnumerable<PROPERTY> viewdetail, IEnumerable<string> expectedTitles)
            {
                viewdetail.Select(x => x.PropertyName).Should().Contain(expectedTitles);
            }
        }
    }


}
