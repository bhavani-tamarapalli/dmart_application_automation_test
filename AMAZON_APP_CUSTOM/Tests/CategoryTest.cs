//using Amazon_Application.Pages;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using NUnit.Framework;
//using System;
//using System.Threading;

//namespace Amazon_Application.Tests
//{
//    public class CategoryTest
//    {
//        private IWebDriver driver;
//        private CategoryPage categoryPage;

//        [SetUp]
//        public void Setup()
//        {
//            driver = new ChromeDriver();
//            driver.Manage().Window.Maximize();
//            driver.Navigate().GoToUrl("https://www.amazon.in/");
//            Thread.Sleep(2000); 
//        }

//        [Test]
//        public void AddFruitsAndVegetablesToCart()
//        {
//            TopNavigationPage topNav = new TopNavigationPage(driver);
//            SubNavigationPage subNav = new SubNavigationPage(driver);
//            CategoryPage category = new CategoryPage(driver);


//            subNav.ClickAllSubNavItems("fresh");


//            category.ClickSubCategory("Fruits & Vegetables");


//            category.ClickProduct("fresh bhendi(lady finger)");

//            categoryPage.ClickSubCategory("Fruits & vegetables"); 
//            categoryPage.AddFirstProductToCart(); 


//            Console.WriteLine("Product added to cart successfully!");
//        }

//        [TearDown]
//        public void Teardown()
//        {
//            driver.Quit();
//            driver.Dispose();
//        }
//    }
//}



//using Amazon_Application.Pages;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using NUnit.Framework;
//using System;
//using System.Threading;

//namespace Amazon_Application.Tests
//{
//    public class CategoryTest
//    {
//        private IWebDriver driver;
//        private CategoryPage categoryPage;

//        [SetUp]
//        public void Setup()
//        {
//            driver = new ChromeDriver();
//            driver.Manage().Window.Maximize();
//            driver.Navigate().GoToUrl("https://www.amazon.in/");
//            Thread.Sleep(2000);

//            // Initialize CategoryPage
//            categoryPage = new CategoryPage(driver);
//        }

//        [Test]
//        public void AddFruitsAndVegetablesToCart()
//        {

//            categoryPage.ClickTopNav("fresh");


//            categoryPage.ClickNestedSubNav("Fruits & Vegetables");


//            categoryPage.AddFirstProductToCart();

//            Console.WriteLine(" Product added to cart successfully!");
//        }


//        [TearDown]
//        public void Teardown()
//        {
//            driver.Quit();
//            driver.Dispose();
//        }
//    }
//}


//using Amazon_Application.Pages;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using NUnit.Framework;
//using System;
//using System.Threading;

//namespace Amazon_Application.Tests
//{
//    public class CategoryTest
//    {
//        private IWebDriver driver;
//        private CategoryPage categoryPage;

//        [SetUp]
//        public void Setup()
//        {
//            driver = new ChromeDriver();
//            driver.Manage().Window.Maximize();
//            driver.Navigate().GoToUrl("https://www.amazon.in/");
//            Thread.Sleep(2000);

//            categoryPage = new CategoryPage(driver);
//        }

//        [Test]
//        public void AddFruitsAndVegetablesToCart()
//        {
//            categoryPage.ClickTopNav();
//            categoryPage.ClickSubCategory();
//            categoryPage.ClickFeaturedTab();
//            categoryPage.AddFirstProductToCart();
//        }

//        [TearDown]
//        public void Teardown()
//        {
//            driver.Quit();
//            driver.Dispose();
//        }
//    }
//}

using Amazon_Application.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using System.Threading;

namespace Amazon_Application.Tests
{
    public class CategoryTest
    {
        private IWebDriver driver;
        private CategoryPage categoryPage;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");

            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.amazon.in/");
            Thread.Sleep(3000);

            categoryPage = new CategoryPage(driver);
        }

        [Test]
        public void AddFruitsAndVegetablesToCart()
        {
            categoryPage.ClickTopNav();
            categoryPage.ClickSubCategory();
            categoryPage.ClickFeaturedTab();
            categoryPage.AddFirstProductToCart();
        }

        [TearDown]
        public void Teardown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}