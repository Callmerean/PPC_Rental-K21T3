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
    class UC02_ViewListOfProjectStep
    {
        private IWebDriver driver = new FirefoxDriver();
        [Given(@"agency am in home page")]
        public void GivenIAmInHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost:4675/");
        }

        [When(@"agency click sign in button")]
        public void WhenIClickSignInButton()
        {
            driver.FindElement(By.Id("Log")).Click();
        }

        [When(@"agency am log in page")]
        public void WhenIAmLogInPage()
        {
            driver.Navigate().GoToUrl("http://localhost:4675/Admin/Client/Login");
        }

        [When(@"agency write account")]
        public void WhenIWriteAccount()
        {
            driver.FindElement(By.Name("username")).SendKeys("lythihuyenchau@gmail.com");
            driver.FindElement(By.Name("password")).SendKeys("123456");
        }

        [When(@"agency Click Log in")]
        public void WhenIClickLogIn()
        {
            driver.FindElement(By.Id("Si")).Click();
        }

        [Then(@"agency stay admin page")]
        public void ThenIStayAdminPage()
        {
            driver.Navigate().GoToUrl("http://localhost:4675/Admin/Client");
        }

    }
}
