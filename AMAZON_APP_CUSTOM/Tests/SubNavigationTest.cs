using Amazon_Application.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Amazon_Application.Tests
{
    public class SubNavigationTest
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
        public void TestTopAndSubNavigation()
        {
            TopNavigationPage topNav = new TopNavigationPage(driver);

            var navItems = topNav.GetTopNavItems();

            for (int i = 0; i < navItems.Count; i++)
            {
               
                navItems = topNav.GetTopNavItems();

                string navText = navItems[i].Text.Trim();
                if (string.IsNullOrEmpty(navText)) continue;

                Console.WriteLine($"==== Testing Top Nav: {navText} ====");

                var subNavPage = topNav.ClickTopNavItem(i);

                if (subNavPage != null)
                {
                    subNavPage.ClickAllSubNavItems();
                }

                driver.Navigate().Back();
                Thread.Sleep(2000);
            }
        }


        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
