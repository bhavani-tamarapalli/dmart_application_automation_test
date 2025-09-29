using Amazon_Application.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Amazon_Application.Pages
{
    public class NavigationPage
    {
        private IWebDriver driver;

        public NavigationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void OpenHamburgerMenu()
        {
            var menuButton = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("HamburgerMenuButton"));

            try
            {
                menuButton.Click();
            }
            catch (ElementClickInterceptedException)
            {
              
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].click();", menuButton);
            }

            Thread.Sleep(2000);
        }

        public void HoverAndClickAllNavItems()
        {
            Actions actions = new Actions(driver);

            for (int i = 0; i < 5; i++) 
            {
                var navItems = new List<IWebElement>(
                    SeleniumCustomMethods.GetElements(driver, ConfigReader.GetLocator("NavMenuItems"))
                );

                if (i >= navItems.Count) break;

                var item = navItems[i];
                string text = item.Text.Trim();

                if (string.IsNullOrEmpty(text)) continue;


                actions.MoveToElement(item).Perform();
                Console.WriteLine("Hovered on: " + text);

                Thread.Sleep(1000);


                item.Click();
                Console.WriteLine("Clicked on: " + text);

                Thread.Sleep(2500);


                driver.Navigate().Back();
                Thread.Sleep(2000);

                OpenHamburgerMenu();
            }
        }
    }
}
