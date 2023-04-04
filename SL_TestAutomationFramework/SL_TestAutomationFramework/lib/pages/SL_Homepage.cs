using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL_TestAutomationFramework.lib.pages
{
    public class SL_Homepage
    {
        private IWebDriver _seleniumDriver;

        private string _homePageUrl = App_ConfigReader.BaseUrl;

        private IWebElement _passwordField => _seleniumDriver.FindElement(By.Id("password"));
        private IWebElement _usernameField => _seleniumDriver.FindElement(By.Id("user-name"));
        private IWebElement _loginbutton => _seleniumDriver.FindElement(By.Id("login-button"));
        private IWebElement _alert => _seleniumDriver.FindElement(By.CssSelector("[data-test=\"error\"]"));

        public SL_Homepage(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
        }

        public void VisitHomePage() => _seleniumDriver.Navigate().GoToUrl(_homePageUrl);
        public void EnterUserName(string username) => _usernameField.SendKeys(username);
        public void EnterPassword(string password) => _passwordField.SendKeys(password);
        public void ClickLoginButton() => _loginbutton.Click();
        public string CheckErrorMessage() => _alert.Text;
        

    }
}
