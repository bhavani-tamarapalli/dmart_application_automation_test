using Amazon_Application.Pages;
using Amazon_Application.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Amazon_Application.Tests;

public class CreateAccTest
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
      
    }


    [Test, Order(1)]
    public void CreateAccountTest()
    {
        // Read test data
        string name = ConfigReader.GetTestData("CreateAccountNameValue");
        string mobile = ConfigReader.GetTestData("CreateAccountMobileValue");
        string password = ConfigReader.GetTestData("CreateAccountPasswordValue");

        string email = ConfigReader.GetTestData("ValidEmail");


        loginPage.ClickSignIn();

        // Enter Email
        loginPage.EnterEmail(email);

        loginPage.ClickContinue();
        loginPage.ClickCreateAccount();

        // Fill Create Account form
        CreateAccountPage createAccount = new CreateAccountPage(driver);
        createAccount.EnterMobile(mobile);
        createAccount.EnterName(name);
        createAccount.EnterPassword(password);
        createAccount.ClickSubmit();

        Assert.Pass("Create account test passed successfully");

    }

    [TearDown]
    public void Teardown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
