using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace PPC_Rental.UITests.Selenium
{
    [Binding]
    class UC01_FilterProjectStep
    {
        private IWebDriver driver = new FirefoxDriver();
        [When(@"I search for projects by the phrase '(.*)','(.*)','(.*)','(.*)','(.*)'")]
        [Given(@"user stay at main home")]
        public void GivenUserStayAtMainHome()
        {
            driver.Navigate().GoToUrl("http://localhost:4675/");
        }

        [When(@"user choose into the location area")]
        public void WhenUserChooseIntoTheLocationArea()
        {
            var option = driver.FindElement(By.Id("dis"));
            var selectElement = new SelectElement(option);
                selectElement.SelectByText("Chương Mỹ");
            
        }

        [When(@"user choose into the type area")]
        public void WhenUserChooseIntoTheTypeArea()
        {
            var option = driver.FindElement(By.Id("type"));
            var selectElement = new SelectElement(option);
              selectElement.SelectByText("Office");
        }

        [When(@"user choose into bedroom area")]
        public void WhenUserChooseIntoBedroomArea()
        {
            var option = driver.FindElement(By.Id("bedRoom"));
            var selectElement = new SelectElement(option);
              selectElement.SelectByText("2");
        }

        [When(@"user choose into bathroom area")]
        public void WhenUserChooseIntoBathroomArea()
        {
            var option = driver.FindElement(By.Id("bathRoom"));
            var selectElement = new SelectElement(option);
             selectElement.SelectByText("2");
        }

        [Then(@"user click Search")]
        public void ThenUserClickSearch()
        {
            driver.FindElement(By.Id("btnSearch")).Click();
        }


    }
}
