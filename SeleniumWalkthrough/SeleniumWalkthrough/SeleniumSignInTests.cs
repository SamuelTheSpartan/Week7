using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;


namespace SeleniumWalkthrough
{
    public class Tests
    {
        [Test]
        [Category("Happy")]
        public void GivenIAmOnTheHomePage_WhenIEnterAValidEmailAndPassword_ThenIShouldLandOnTheInvestoryPage()
        {
            //ANYTHING that we put into a using block MUST implement the IDisposable interface. It only contain one method called Dispose().
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.saucedemo.com");
                var userNameField = driver.FindElement(By.Id("user-name"));
                userNameField.SendKeys("standard_user");
                var passwordField = driver.FindElement(By.Id("password"));
                passwordField.SendKeys("secret_sauce");
                var loginButton = driver.FindElement(By.Name("login-button"));
                loginButton.Click();

                Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));

            }
        }

        [Test]
        [Category("Happy")]
        public void GivenIAmOnTheHomePage_WhenIEnterValidEmailAndInvalidPassword_ThenIShouldReceiveAnErrorMessage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.saucedemo.com");
                var userNameField = driver.FindElement(By.Id("user-name"));
                userNameField.SendKeys("standard_user");
                var passwordField = driver.FindElement(By.Id("password"));
                passwordField.SendKeys("incorrect_passowrd");
                var loginButton = driver.FindElement(By.Name("login-button"));
                loginButton.Click();
                var loginErrorText = "Epic sadface: Username and password do not match any user in this service";

                Assert.That(driver.FindElement(By.CssSelector("*[data-test=\"error\"]")).Text, Does.Contain(loginErrorText));

                //var errorMessage = driver.FindElement(By.CssSelector("*[data-test=\"error\"]")).Text;
                //Assert.That(errorMessage, Is.EqualTo("Epic sadface: Username and password do not match any user in this service"));
                Thread.Sleep(100);
            }
        }

        [Test]
        [Repeat(10)]
        [Category("Happy")]
        public void GivenIAmOnTheDragAndDropPage_WhenIDragBoxAToBoxB_ThenBoxBTextIsUpdatedtoDropped()
        {
            var options = new ChromeOptions();
            options.AddArgument("headless");

            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Manage().Window.Maximize();
                Actions actionBuilder = new Actions(driver);
                driver.Navigate().GoToUrl("https://demoqa.com/droppable/");
                Thread.Sleep(1000);
                var draggableBox = driver.FindElement(By.Id("draggable"));
                var dropBox = driver.FindElement(By.Id("droppable"));
                actionBuilder.DragAndDrop(draggableBox, dropBox).Perform();
                
                var dropBoxMessage = driver.FindElement(By.Id("droppable")).FindElement(By.TagName("p")).Text;
                Assert.That(dropBoxMessage, Is.EqualTo("Dropped!"));
                
            }
        }
    }
}