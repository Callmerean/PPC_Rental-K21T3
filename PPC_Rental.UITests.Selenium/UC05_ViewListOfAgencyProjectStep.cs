using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;


namespace PPC_Rental.UITests.Selenium
{
    [Binding]
    class UC05_ViewListOfAgencyProjectStep
    {
        private IWebDriver driver = new FirefoxDriver();
        [Given(@"sale  in home page")]
        public void GivenSaleInHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost:4675/");
        }

        [When(@"sale click sign in button")]
        public void WhenSaleClickSignInButton()
        {
            driver.FindElement(By.Id("Log")).Click();
        }

        [When(@"sale  log in page")]
        public void WhenSaleLogInPage()
        {
            driver.Navigate().GoToUrl("http://localhost:4675/Client/Login");
        }

        [When(@"sale write account")]
        public void WhenSaleWriteAccount()
        {
            driver.FindElement(By.Name("username")).SendKeys("callmerean@gmail.com");
            driver.FindElement(By.Name("password")).SendKeys("123456");
        }

        [When(@"sale Click Log in")]
        public void WhenSaleClickLogIn()
        {
            driver.FindElement(By.Id("login")).Click();
        }

        [Then(@"sale stay admin page")]
        public void ThenSaleStayAdminPage()
        {
            driver.Navigate().GoToUrl("http://localhost:4675/Admin/AdminProperty");
        }
        
    }
}
