using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;


namespace PPC_Rental.UITests.Selenium.Step
{
    [Binding]
    class UC05_ViewListOfAgencyProjectStep
    {
        private IWebDriver driver = new FirefoxDriver();
        [Given(@"sale am in home page")]
        public void GivenIAmInHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost:4675/");
        }

        [When(@"sale click sign in button")]
        public void WhenIClickSignInButton()
        {
            driver.FindElement(By.Id("Log")).Click();
        }

        [When(@"sale am log in page")]
        public void WhenIAmLogInPage()
        {
            driver.Navigate().GoToUrl("http://localhost:4675/Client/Login");
        }

        [When(@"sale write account")]
        public void WhenIWriteAccount()
        {
            driver.FindElement(By.Name("username")).SendKeys("votrunghau112233@gmail.com");
            driver.FindElement(By.Name("password")).SendKeys("votrunghau");
        }

        [When(@"sale Click Log in")]
        public void WhenIClickLogIn()
        {
            driver.FindElement(By.Id("Si")).Click();
        }

        [Then(@"sale stay admin page")]
        public void ThenIStayAdminPage()
        {
            driver.Navigate().GoToUrl("http://localhost:4675/Admin/AdminProperty");
        }

    }
}
