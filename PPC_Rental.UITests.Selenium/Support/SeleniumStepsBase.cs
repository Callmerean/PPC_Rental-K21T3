using OpenQA.Selenium;

namespace PPC_Rental.UITests.Selenium.Support
{
    public abstract class SeleniumStepsBase
    {
        // ReSharper disable InconsistentNaming
        protected IWebDriver Browser
        // ReSharper restore InconsistentNaming
        {
            get { return SeleniumController.Instance.Browser; }
        }
    }
}