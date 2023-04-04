using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SL_TestAutomationFramework.lib.driver_config;

namespace SL_TestAutomationFramework.lib.pages
{
    // Superclass - essential acting as a service object for all pages
    // i.e decomposes objects in manageable classes and methods
    public class SL_Website<T> where T : IWebDriver, new()
    {
        #region Accessible page objects and selenium driver

        public IWebDriver SeleniumDriver { get; set; }

        public SL_Homepage Sl_HomePage { get; set; }

        public SL_InventoryPage Sl_Inventory { get; set; }

        #endregion


        public SL_Website(int pageLoadInSecs = 10, int implicitWaitInSecs = 10, bool isHeadless = false)
        {
            // Instantiated our driver
            SeleniumDriver = new SeleniumDriverConfig<T>(pageLoadInSecs, implicitWaitInSecs, isHeadless).Driver;
            Sl_HomePage = new SL_Homepage(SeleniumDriver);
            Sl_Inventory = new SL_InventoryPage(SeleniumDriver);
        }

    }
}
