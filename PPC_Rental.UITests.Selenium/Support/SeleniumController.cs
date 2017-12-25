using System;
using System.Configuration;
using System.Diagnostics;
using OpenQA.Selenium;
using PPC_Rental.UITests.Selenium.Config;

namespace PPC_Rental.UITests.Selenium.Support
{
    public class SeleniumController
    {
        public static SeleniumController Instance = new SeleniumController();
        private IisExpressWebServer WebServer;
        public IWebDriver Browser { get; private set; }

        public string BaseUrl
        {
            get { return ConfigurationManager.AppSettings["http://localhost:4675/"]; }
        }

        public void Start()
        {
            if (!(Browser == null))
            {
                return;
            }

            //Start web server to deploy and run app
            StartIisExpress();

            Browser = Browsers.Firefox;

            Trace("Selenium started");
        }

        public void Stop()
        {
            if (Browser == null)
            {
                return;
            }

            try
            {
                Browser.Quit();
                Browser.Dispose();
                WebServer.Stop();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc, "Selenium stop error");
            }

            Browser = null;
            Trace("Selenium stopped");
        }

        private static void Trace(string message) { Console.WriteLine("-> {}", message); }

        private void StartIisExpress()
        {
            int PortNumber = int.Parse(this.BaseUrl.Substring(this.BaseUrl.LastIndexOf(':') + 1, 5));

            var app = new WebApplication(ProjectLocation.FromFolder("BookShop"), PortNumber);
            app.AddEnvironmentVariable("UITests");
            WebServer = new IisExpressWebServer(app);
            WebServer.Start("Release");
        }
    }
}
