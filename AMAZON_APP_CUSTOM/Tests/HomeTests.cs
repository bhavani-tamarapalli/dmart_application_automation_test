using Amazon_Application.Pages;
using Amazon_Application.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Amazon_Application.Tests
{
   
    public class HomeTests
    {
        private IWebDriver driver;
        private HomePage homePage;
        private LoginPage loginPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.amazon.in/");
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);

           
            string mobile = ConfigReader.GetTestData("ValidMobile");
            string password = ConfigReader.GetTestData("ValidPassword");

            loginPage.ClickSignIn();
            loginPage.EnterMobile(mobile);
            loginPage.ClickContinue();
            loginPage.EnterPassword(password);
            loginPage.ClickSignInSubmit();
        }

        [Test, Order(1)]
        public void ClickLogoTest()
        {
            homePage.ClickLogo();
            Assert.Pass("Logo clicked successfully");
        }

        [Test, Order(2)]
        public void ClickDeliveryOptionTest()
        {
            homePage.ClickLogo();
            homePage.ClickDeliveryOption();
            Assert.Pass("Delivery option clicked successfully");
        }

        [Test, Order(3)]
        public void DeliveryOptionCloseTest()
        {
            homePage.ClickLogo();
            homePage.ClickDeliveryOption();
            homePage.CloseDeliveryModal();
            Assert.Pass("Delivery option modal closed successfully");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
