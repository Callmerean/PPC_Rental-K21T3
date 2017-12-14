using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using System.Threading;
namespace PPC_Rental.AcceptanceTests.Step
{
    [Binding]
    class EditofagencyprojectStep
    {
        private IWebDriver driver = new ChromeDriver();
        [Given(@"Mở trang trủ")]
        public void GivenMởTrangTrủ()
        {
            driver.Navigate().GoToUrl("http://localhost:4675/");
            Thread.Sleep(5);
        }

        [When(@"Bấm vào nút login")]
        public void WhenBấmVaoNutLogin()
        {
            driver.FindElement(By.Id("btnLogin1")).Click();
            Thread.Sleep(5);
        }

        [When(@"Nhập tài khoảng")]
        public void WhenNhậpTaiKhoảng()
        {
            driver.FindElement(By.Id("UserName1")).SendKeys("lythihuyenchau@gmail.com");
            Thread.Sleep(5);
            driver.FindElement(By.Id("Password1")).SendKeys("123456");
            Thread.Sleep(5);
            driver.FindElement(By.Id("btnLogin2")).Click();
            Thread.Sleep(5);
        }

        [When(@"Agency bấm vào Edit Agency project")]
        public void WhenAgencyBấmVaoEditAgencyProject()
        {
           // driver.FindElement(By.Id("btnEdit1")).Click();
            driver.Navigate().GoToUrl("http://localhost:4675/Admin/Client/Edit/11");
            Thread.Sleep(5);
        }

        [Then(@"Agency bấm vào OK\.")]
        public void ThenAgencyBấmVaoOK_()
        {
            driver.FindElement(By.Id("btnSubmit1")).Click();
            Thread.Sleep(5);
        }


    }
}
