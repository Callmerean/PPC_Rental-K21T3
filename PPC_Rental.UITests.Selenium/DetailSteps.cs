using System.Linq;
using TechTalk.SpecFlow;
using PPC_Rental.AcceptanceTests.Common;
using PPC_Rental.UITests.Selenium.Support;
using PPC_Rental.Models;
using OpenQA.Selenium;

namespace PPC_Rental.UITests.Selenium
{
    // thêm tag web vs cấu hình lại app config thì k chạy được, thôi thì làm trên acceptance test được rùi nha cô, 3h sáng rùi e chết đây :D
    [Binding]
    public class DetailSteps: SeleniumStepsBase
    {
       
        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOf(string p0)
        {
            Browser.NavigateTo("Home");
            //Input value to search for
            Browser.ClickButton("btnDetail");
            //Click on search button
            
        }
        [Then(@"the property details should show")]
        public void ThenThePropertyDetailsShouldShow(string expectedTitles)
        {
            var expectedResult = expectedTitles.Split(',').Select(x => x.Trim('\''));
            Browser.SwitchTo().DefaultContent();
            var viewdetail = from row in Browser.FindElements(By.XPath("//div[contains(@id,'detail-header')]/p"))
                             let Name = row.Text
                             select new PROPERTY { PropertyName = Name };
            PropertyAssertion.ViewDetailProject(viewdetail, expectedResult);
        }

    }
}
