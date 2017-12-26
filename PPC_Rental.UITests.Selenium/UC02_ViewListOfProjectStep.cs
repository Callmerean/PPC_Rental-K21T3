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
    class UC02_ViewListOfProjectStep
    {
        private IWebDriver driver = new FirefoxDriver();
        [Given(@"agency  in home page")]
        public void GivenAgencyInHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost:4675/");
        }

        [When(@"agency click sign in button")]
        public void WhenAgencyClickSignInButton()
        {
            driver.FindElement(By.Id("Log")).Click();
        }

        [When(@"agency  log in page")]
        public void WhenAgencyLogInPage()
        {
            driver.Navigate().GoToUrl("http://localhost:4675/Client/Login");
        }

        [When(@"agency write account")]
        public void WhenAgencyWriteAccount()
        {
             driver.FindElement(By.Name("username")).SendKeys("lythihuyenchau@gmail.com");
            driver.FindElement(By.Name("password")).SendKeys("123456");
        }

        [When(@"agency Click Log in")]
        public void WhenAgencyClickLogIn()
        {
            driver.FindElement(By.Id("login")).Click();
        }

        [Then(@"agency stay admin page")]
        public void ThenAgencyStayAdminPage()
        {
           driver.Navigate().GoToUrl("http://localhost:4675/Admin/AdminProperty");
        }

       
    }
}
