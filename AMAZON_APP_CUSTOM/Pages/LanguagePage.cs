using Amazon_Application.Utilities;
using OpenQA.Selenium;

namespace Amazon_Application.Pages
{
    public class LanguagePage
    {
        private IWebDriver driver;

        public LanguagePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void OpenLanguageDropdown()
        {
            var dropdown = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("LanguageDropdown"));
            dropdown.Click();
            Thread.Sleep(1000);
        }

        public void LoopThroughAllLanguages()
        {
            OpenLanguageDropdown();

            var options = SeleniumCustomMethods.GetElements(driver, ConfigReader.GetLocator("LanguageOptionList"));

            for (int i = 1; i < options.Count; i++)
            {
                // Re-fetch the options after each click, because DOM may reload
                options = SeleniumCustomMethods.GetElements(driver, ConfigReader.GetLocator("LanguageOptionList"));

               


                // Click Save
                var saveBtn = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("SaveLanguageButton"));
                saveBtn.Click();

                Thread.Sleep(1500); // wait for page reload

                // Reopen language dropdown for next iteration if not last
                if (i < options.Count - 1)
                {
                    OpenLanguageDropdown();
                }
            }
        }
    }

}
