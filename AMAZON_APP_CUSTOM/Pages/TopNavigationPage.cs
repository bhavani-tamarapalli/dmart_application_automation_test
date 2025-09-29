using Amazon_Application.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Amazon_Application.Pages
{
    public class TopNavigationPage
    {
        private IWebDriver driver;

        public TopNavigationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void HoverAndClickTopNavItems()
        {
            Actions actions = new Actions(driver);

           
            IWebElement navParent = driver.FindElement(By.Id(ConfigReader.GetLocator("TopNavItemsParentId")));

         
            var navItems = navParent.FindElements(By.TagName("a"));

            for (int i = 0; i < navItems.Count; i++)
            {
                var item = navItems[i];
                string text = item.Text.Trim();

                if (string.IsNullOrEmpty(text)) continue;

                // Hover on nav item
                actions.MoveToElement(item).Perform();
                Console.WriteLine("Hovered on: " + text);

                Thread.Sleep(1000);

                item.Click();
                Console.WriteLine("Clicked on: " + text);

                Thread.Sleep(2000);

                
                driver.Navigate().Back();
                Thread.Sleep(2000);

               
                navParent = driver.FindElement(By.Id(ConfigReader.GetLocator("TopNavItemsParentId")));
                navItems = navParent.FindElements(By.TagName("a"));
            }
        }
    }




}
