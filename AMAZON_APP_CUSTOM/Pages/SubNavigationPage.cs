using Amazon_Application.Utilities;
using OpenQA.Selenium;

namespace Amazon_Application.Pages
{
    public class SubNavigationPage
    {
        private IWebDriver driver;

        public SubNavigationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

      
        public void ClickAllSubNavItems()
        {
            var subNavContainers = driver.FindElements(By.ClassName(ConfigReader.GetLocator("SubNavContainerClass"))).ToList();

            foreach (var container in subNavContainers)
            {
                var subItems = container.FindElements(By.TagName("a")).ToList();

                foreach (var subItem in subItems)
                {
                    string text = subItem.Text.Trim();
                    if (string.IsNullOrEmpty(text)) continue;

                    try
                    {
                        subItem.Click();
                        Console.WriteLine("Clicked sub-nav item: " + text);
                        Thread.Sleep(2000);

                        driver.Navigate().Back();
                        Thread.Sleep(2000);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Could not click sub-nav item: {text} - {ex.Message}");
                    }
                }
            }
        }
    }
}
