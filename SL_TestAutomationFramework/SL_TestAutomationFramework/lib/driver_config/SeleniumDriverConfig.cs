using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL_TestAutomationFramework.lib.driver_config
{

    // New keyword - can't be abstract type
    // Specify the type when we istantiate the DriverConfig
    // But the type MUST be of IWebDriver type
    public class SeleniumDriverConfig<T> where T : IWebDriver,new()
    {
        //Driver property for later use
        public IWebDriver Driver { get; set; }

        public SeleniumDriverConfig(int pageLoadInSecs, int implicitWaitInSecs, bool isHeadless)
        {
            Driver = new T();
            DriverSetup(pageLoadInSecs, implicitWaitInSecs, isHeadless);
        }

        private void DriverSetup(int pageLoadInSecs, int implicitWaitInSecs, bool isHeadless)
        {
            // This is the time the driver will wiat for the page to load
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadInSecs);

            // This is the time the driver waits for the elements to load
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitInSecs);

            if (isHeadless)
            {
                SetHeadless();
            }
        }

        private void SetHeadless()
        {
            if (Driver is ChromeDriver)
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("headless");
                Driver = new ChromeDriver();
            }
            else if (Driver is FirefoxDriver)
            {
                FirefoxOptions options = new FirefoxOptions();
                options.AddArgument("--healdess");
                Driver = new FirefoxDriver(options);
            }
            else
            {
                throw new ArgumentException("Driver not supported by framework");
            }
        }
    }
}
