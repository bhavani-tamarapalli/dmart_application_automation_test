using Amazon_Application.Pages;
using Amazon_Application.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Amazon_Application.Tests
{

    public class SearchTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;
        private SearchPage searchPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.amazon.in/");
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            searchPage = new SearchPage(driver);

            // login before search
            //string mobile = ConfigReader.GetTestData("ValidMobile");
            //string password = ConfigReader.GetTestData("ValidPassword");

            //loginPage.ClickSignIn();
            //loginPage.EnterMobile(mobile);
            //loginPage.ClickContinue();
            //loginPage.EnterPassword(password);
            //loginPage.ClickSignInSubmit();
        }

        [Test, Order(1)]
        public void SearchDropdownCategoriesTest()
        {
            homePage.ClickLogo();
            searchPage.SelectAndClickAllDropdownOptions();
            Assert.Pass("Successfully iterated through all categories in search dropdown.");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
