using Amazon_Application.Pages;
using Amazon_Application.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Amazon_Application.Tests
{
    [TestFixture]
    public class LoginTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.amazon.in/");
            loginPage = new LoginPage(driver);
        }

        [Test, Order(1)]
        public void ValidEmailSignInTest()
        {
            // Read test data from App.config
            string validEmail = ConfigReader.GetTestData("ValidEmail");


            // Perform login steps
            loginPage.ClickSignIn();
            loginPage.EnterEmail(validEmail);
            loginPage.ClickContinue();

            Assert.Pass("Valid email sign-in test passed successfully");
        }

        [Test, Order(2)]
        public void ValidMobileSignInTest()
        {
            string validMobile = ConfigReader.GetTestData("ValidMobile");

            loginPage.ClickSignIn();
            loginPage.EnterMobile(validMobile);
            loginPage.ClickContinue();


            Assert.Pass("Valid mobile sign-in test passed successfully");
        }

        [Test, Order(3)]
        public void ValidMobileLoginTest()
        {
            string mobile = ConfigReader.GetTestData("ValidMobile");
            string password = ConfigReader.GetTestData("ValidPassword");

            loginPage.ClickSignIn();
            loginPage.EnterMobile(mobile);
            loginPage.ClickContinue();
            loginPage.EnterPassword(password);
            loginPage.ClickSignInSubmit();

            Assert.Pass("Valid mobile login test passed successfully");
        }

        [Test, Order(4)]
        public void ValidEmailLoginTest()
        {
            string email = ConfigReader.GetTestData("ValidEmail");

            // Click Sign In on Amazon homepage
            loginPage.ClickSignIn();

            // Enter Email
            loginPage.EnterEmail(email);

            loginPage.ClickContinue();
            loginPage.ClickCreateAccount();


            Assert.Pass("Valid email login test passed successfully");
        }

        //[Test, Order(5)]
        //public void CreateAccountTest()
        //{
        //    // Read test data
        //    string name = ConfigReader.GetTestData("CreateAccountNameValue");
        //    string mobile = ConfigReader.GetTestData("CreateAccountMobileValue");
        //    string password = ConfigReader.GetTestData("CreateAccountPasswordValue");

        //    string email = ConfigReader.GetTestData("ValidEmail");


        //    loginPage.ClickSignIn();

        //    // Enter Email
        //    loginPage.EnterEmail(email);

        //    loginPage.ClickContinue();
        //    loginPage.ClickCreateAccount();

        //    // Fill Create Account form
        //    CreateAccountPage createAccount = new CreateAccountPage(driver);
        //    createAccount.EnterMobile(mobile);
        //    createAccount.EnterName(name);
        //    createAccount.EnterPassword(password);
        //    createAccount.ClickSubmit();

        //    Assert.Pass("Create account test passed successfully");

        //}

        [Test, Order(6)]
        public void MobileLoginAndClickLogoTest()
        {

            string mobile = ConfigReader.GetTestData("ValidMobile");
            string password = ConfigReader.GetTestData("ValidPassword");

            loginPage.ClickSignIn();

            loginPage.EnterMobile(mobile);
            loginPage.ClickContinue();

            loginPage.EnterPassword(password);
            loginPage.ClickSignInSubmit();

            loginPage.ClickLogo();

            Assert.Pass("Mobile login and click logo test passed successfully");

        }

        //[Test, Order(7)]
        //public void ClickDeliveryOptionTest()
        //{
        //    //string mobile = ConfigReader.GetTestData("ValidMobile");
        //    //string password = ConfigReader.GetTestData("ValidPassword");
        //    //loginPage.ClickSignIn();
        //    //loginPage.EnterMobile(mobile);
        //    //loginPage.ClickContinue();
        //    //loginPage.EnterPassword(password);
        //    //loginPage.ClickSignInSubmit();


        //    loginPage.ClickLogo();
        //    loginPage.ClickDeliveryOption();
        //    Assert.Pass("Click delivery option test passed successfully");
        //}

        //[Test,Order(8)]
        //public void DeliveryOptionCloseTest()
        //{
        //    //string mobile = ConfigReader.GetTestData("ValidMobile");
        //    //string password = ConfigReader.GetTestData("ValidPassword");

        //    //// Login steps
        //    //loginPage.ClickSignIn();
        //    //loginPage.EnterMobile(mobile);
        //    //loginPage.ClickContinue();
        //    //loginPage.EnterPassword(password);
        //    //loginPage.ClickSignInSubmit();
        //    loginPage.ClickLogo();

        //    // Open and close delivery option modal
        //    loginPage.ClickDeliveryOption();
        //    loginPage.CloseDeliveryModal();

        //    Assert.Pass("Delivery option close test passed successfully");
        //}

        //[Test, Order(9)]


        //public void SelectAllCategoriesTest()
        //{
        //    string mobile = ConfigReader.GetTestData("ValidMobile");
        //    string password = ConfigReader.GetTestData("ValidPassword");

        //    loginPage.ClickSignIn();
        //    loginPage.EnterMobile(mobile);
        //    loginPage.ClickContinue();
        //    loginPage.EnterPassword(password);
        //    loginPage.ClickSignInSubmit();
        //    loginPage.ClickLogo();

        //    loginPage.SelectAllSearchDropdownOptions();

        //    Assert.Pass("Successfully iterated through all categories in search dropdown.");
        //}

        //public void SearchDropdownCategoriesTest()
        //{

        //    loginPage.ClickLogo();


        //    loginPage.SelectAndClickAllDropdownOptions();

        //    Assert.Pass("Successfully hovered and clicked all categories from search dropdown.");
        //}


        private bool closeBrowser = false;

        [TearDown]
        public void Teardown()
        {
            if (closeBrowser && driver != null)
            {
                driver.Quit();
                driver.Dispose();

            }
        }
    }
}
