using Amazon_Application.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Amazon_Application.Tests;

public class NavigationTest
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
    public void HoverAndClickNavItemsTest()
    {
        NavigationPage navigationPage = new NavigationPage(driver);

        // Open once
        navigationPage.OpenHamburgerMenu();

        // Loop over and test nav items
        navigationPage.HoverAndClickAllNavItems();

        Assert.Pass("Navigation items hovered and clicked successfully.");
    }

    [TearDown]
    public void Teardown()
    {
        driver.Quit();
        driver.Dispose();
    }

}
