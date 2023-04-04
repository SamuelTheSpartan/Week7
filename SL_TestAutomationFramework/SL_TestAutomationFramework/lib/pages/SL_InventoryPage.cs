using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL_TestAutomationFramework.lib.pages
{
    public class SL_InventoryPage
    {
        private IWebDriver _seleniumDriver;

        public SL_InventoryPage(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
        }
    }
}
