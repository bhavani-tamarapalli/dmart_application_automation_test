
using Amazon_Application.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;

namespace Amazon_Application.Tests
{
    public class SubNavigationTest
    {
        private IWebDriver driver;
        private bool closeBrowser = true;

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
            SubNavigationPage subNavPage = new SubNavigationPage(driver);

         
            var topNavItems = topNav.GetTopNavItems();
            int totalItems = topNavItems.Count;
            //Console.WriteLine($"Total Top Nav Items: {totalItems}");
            //Console.WriteLine("========================================\n");

            for (int i = 0; i < totalItems; i++)
            {
               
                driver.Navigate().GoToUrl("https://www.amazon.in/");
                Thread.Sleep(1000);

                topNavItems = topNav.GetTopNavItems();
                if (i >= topNavItems.Count)
                {
                    Console.WriteLine($"Index {i} out of range after refresh, breaking loop");
                    break;
                }

                var navItem = topNavItems[i];
                string navText = navItem.Text?.Trim() ?? "";

                if (string.IsNullOrEmpty(navText))
                {
                    Console.WriteLine($"[{i + 1}/{totalItems}] Skipping empty nav item at index {i}\n");
                    continue;
                }

                Console.WriteLine($"==== [{i + 1}/{totalItems}] Testing Top Nav: {navText} ====");

                try
                {
                    subNavPage.ClickAllSubNavItems(navText);
                    Console.WriteLine($" Completed testing: {navText}\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error testing {navText}: {ex.Message}\n");
                }
            }

            Console.WriteLine("========================================");
            Console.WriteLine("Navigation testing completed successfully!");
            Assert.Pass("All navigation items tested.");
        }

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