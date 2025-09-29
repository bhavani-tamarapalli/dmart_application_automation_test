using Amazon_Application.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Amazon_Application.Pages
{
    public class SearchPage
    {
        private IWebDriver driver;

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        public void SelectAndClickAllDropdownOptions()
        {
            var dropdown = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("SearchDropdownBox"));
            var select = new SelectElement(dropdown);

            for (int i = 0; i < select.Options.Count; i++)
            {
                select.SelectByIndex(i);
                Console.WriteLine("Selected: " + select.Options[i].Text);

                Thread.Sleep(800);

                var searchButton = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("SearchButton"));
                searchButton.Click();

                Thread.Sleep(1500);
                driver.Navigate().Back();

                dropdown = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("SearchDropdownBox"));
                select = new SelectElement(dropdown);
            }
        }
    }
}
