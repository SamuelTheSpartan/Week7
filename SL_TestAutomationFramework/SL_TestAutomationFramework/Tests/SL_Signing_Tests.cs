using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SL_TestAutomationFramework.lib.pages;

namespace SL_TestAutomationFramework.Tests
{
    public class SL_Signing_Tests
    {
        private SL_Website<ChromeDriver> SL_Website = new();

        [Test]
        [Category("Happy")]
        public void GivenIAmOnTheHomePage_WhenIENterAValidEmailAndValidPassword_ThenIShouldLandOnTheInventory()
        {
            SL_Website.SeleniumDriver.Manage().Window.Maximize();

            SL_Website.Sl_HomePage.VisitHomePage();
            SL_Website.Sl_HomePage.EnterUserName(App_ConfigReader.UserName);
            SL_Website.Sl_HomePage.EnterPassword(App_ConfigReader.Password);
            SL_Website.Sl_HomePage.ClickLoginButton();

            Assert.That(SL_Website.SeleniumDriver.Url, Is.EqualTo(App_ConfigReader.InventoryPageUrl));
        }

        [Test]
        [Category("Sad")]
        public void GivenIAmOnTheHomePage_WhenIEnterAValidEmailAndInvalidPassword_ThenIShouldSeeAnErrorMessage_WhichContainsEpicSadFace()
        {
            SL_Website.SeleniumDriver.Manage().Window.Maximize();

            SL_Website.Sl_HomePage.VisitHomePage();
            SL_Website.Sl_HomePage.EnterUserName(App_ConfigReader.UserName);
            SL_Website.Sl_HomePage.EnterPassword("Incorrect Password");
            SL_Website.Sl_HomePage.ClickLoginButton();

            Assert.That(SL_Website.SeleniumDriver.FindElement(By.CssSelector("*[data-test=\"error\"]")).Text, Does.Contain("Epic sadface:"));
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            SL_Website.SeleniumDriver.Quit();
            //SL_Website.SeleniumDriver.Dispose();
        }
    }
}