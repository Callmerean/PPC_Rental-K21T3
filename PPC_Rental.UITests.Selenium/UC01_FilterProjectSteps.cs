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
    public class UC01_FilterProjectStep
    {
        private IWebDriver driver = new FirefoxDriver();


        [Given(@"user stay at mainhome")]
        public void GivenIStayAtMainhome()
        {
            driver.Navigate().GoToUrl("http://localhost:4675/");
        }

        [When(@"user choose into the location area")]
        public void WhenIChooseIntoTheLocationArea()
        {

            var option = driver.FindElement(By.Id("dis"));
            var selectElement = new SelectElement(option);

            selectElement.SelectByText("Chương Mỹ");
            Thread.Sleep(5);

        }

        [When(@"user choose into the type area")]
        public void WhenIChooseIntoTheTypeArea()
        {
            var option = driver.FindElement(By.Id("type"));
            var selectElement = new SelectElement(option);

            selectElement.SelectByText("Office");
            Thread.Sleep(5);
        }

        [When(@"user choose into bedroom area")]
        public void WhenIChooseIntoBedroomArea()
        {
            var option = driver.FindElement(By.Id("bedRoom"));
            var selectElement = new SelectElement(option);

            selectElement.SelectByText("2");
            Thread.Sleep(5);
        }

        [When(@"user choose into bathroom area")]
        public void WhenIChooseIntoBathroomArea()
        {
            var option = driver.FindElement(By.Id("bathRoom"));
            var selectElement = new SelectElement(option);

            selectElement.SelectByText("2");
            Thread.Sleep(5);



        }

        [Then(@"user click Search")]
        public void WhenIClickSearch()
        {
            driver.FindElement(By.Id("btnSearch")).Click();
        }


    }
}
