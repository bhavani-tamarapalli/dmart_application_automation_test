using Amazon_Application.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Amazon_Application.Tests;

public class TopNavigationTest
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

    [Test]
    public void HoverAndClickTopNavItemsTest()
    {
        TopNavigationPage topNav = new TopNavigationPage(driver);

     
        topNav.HoverAndClickTopNavItems();

        Assert.Pass("Top navigation items hovered and clicked successfully.");
    }


    [TearDown]
    public void Teardown()
    {
        driver.Quit();
        driver.Dispose();
    }
}
