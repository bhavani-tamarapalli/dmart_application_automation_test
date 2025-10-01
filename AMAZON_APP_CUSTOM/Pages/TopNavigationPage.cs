
using Amazon_Application.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Amazon_Application.Pages
{
    public class TopNavigationPage
    {
        private IWebDriver driver;

        public TopNavigationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public List<IWebElement> GetTopNavItems()
        {
            IWebElement navParent = driver.FindElement(By.Id(ConfigReader.GetLocator("TopNavItemsParentId")));
            return navParent.FindElements(By.TagName("a")).ToList();
        }

        // Hover + Click top nav item
        public void HoverTopNavItem(IWebElement navItem)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(navItem).Perform();
            Thread.Sleep(1000);
        }

        public SubNavigationPage ClickTopNavItem(int index)
        {
            var navItems = GetTopNavItems();
            if (index < 0 || index >= navItems.Count) throw new ArgumentOutOfRangeException(nameof(index));

            var item = navItems[index];
            HoverTopNavItem(item);

            Console.WriteLine("Clicked Top Nav: " + item.Text);
            item.Click();
            Thread.Sleep(2000);

            return new SubNavigationPage(driver);
        }
    }
}
