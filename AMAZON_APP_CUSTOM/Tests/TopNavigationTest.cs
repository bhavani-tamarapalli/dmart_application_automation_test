//using Amazon_Application.Pages;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;

//namespace Amazon_Application.Tests;

//public class TopNavigationTest
//{

//    private IWebDriver driver;
//    private HomePage homePage;
//    private LoginPage loginPage;

//    [SetUp]
//    public void Setup()
//    {
//        driver = new ChromeDriver();
//        driver.Manage().Window.Maximize();
//        driver.Navigate().GoToUrl("https://www.amazon.in/");
//        loginPage = new LoginPage(driver);
//        homePage = new HomePage(driver);
//    }

//    [Test]
//    public void HoverAndClickTopNavItemsTest()
//    {
//        TopNavigationPage topNav = new TopNavigationPage(driver);


//        topNav.HoverAndClickTopNavItems();

//        Assert.Pass("Top navigation items hovered and clicked successfully.");
//    }


//    [TearDown]
//    public void Teardown()
//    {
//        driver.Quit();
//        driver.Dispose();
//    }
//}

using Amazon_Application.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Amazon_Application.Tests
{
    public class TopNavigationTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.amazon.in/");
        }
        [Test]

       
        public void HoverAndClickTopNavItemsTest()
        {
            TopNavigationPage topNav = new TopNavigationPage(driver);
            SubNavigationPage subNavPage = new SubNavigationPage(driver);

            int topNavCount = topNav.GetTopNavItems().Count; // fixed

            for (int i = 0; i < topNavCount; i++)
            {
                // Re-fetch top nav items every iteration to avoid stale element
                var navItems = topNav.GetTopNavItems();
                var navItem = navItems[i];

                string navText = navItem.Text.Trim(); // get text
                if (string.IsNullOrEmpty(navText)) continue;

                Console.WriteLine($"==== Testing Top Nav: {navText} ====");

                // Pass string instead of IWebElement
                subNavPage.ClickAllSubNavItems(navText);
            }

            Assert.Pass("Top navigation and subnav items clicked successfully.");
        }


        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
