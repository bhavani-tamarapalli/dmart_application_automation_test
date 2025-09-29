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

namespace Amazon_Application.Tests
{
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

            var navItems = topNav.GetTopNavItems();

            for (int i = 0; i < navItems.Count; i++)
            {
              
                navItems = topNav.GetTopNavItems();

                var item = navItems[i];
                string navText = item.Text.Trim();

                if (string.IsNullOrEmpty(navText)) continue;

                Console.WriteLine($"==== Testing Top Nav: {navText} ====");

                // Click nav item and go into it
                var subNavPage = topNav.ClickTopNavItem(i);

                // If subnav exists, handle it
                if (subNavPage != null)
                {
                    subNavPage.ClickAllSubNavItems();
                }

                // Navigate back to main page
                driver.Navigate().Back();
                Thread.Sleep(2000);
            }

            Assert.Pass("Top navigation items clicked successfully.");
        }


        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
