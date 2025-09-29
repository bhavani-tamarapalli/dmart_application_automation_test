//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.UI;
//using System;

//namespace Amazon_Application.Utilities
//{
//    public class SeleniumCustomMethod
//    {
//        private readonly IWebDriver _driver;
//        private readonly WebDriverWait _wait;

//        public SeleniumCustomMethod(IWebDriver driver, int timeoutInSeconds = 10)
//        {
//            _driver = driver;
//            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutInSeconds));
//        }

//        public IWebElement SafeFindElement(By locator, int timeout = 10)
//        {
//            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeout));
//            return wait.Until(d => d.FindElement(locator));
//        }

//        public void SafeClick(By locator, int timeout = 15)
//        {
//            SafeFindElement(locator, timeout).Click();
//        }

//        public void SafeType(By locator, string text, int timeout = 10)
//        {
//            var element = SafeFindElement(locator, timeout);
//            element.Clear();
//            element.SendKeys(text);
//        }

//        public string SafeGetText(By locator, int timeout = 10)
//        {
//            return SafeFindElement(locator, timeout).Text;
//        }

//        public string GetAttribute(By locator, string attributeName, int timeout = 10)
//        {
//            return SafeFindElement(locator, timeout).GetAttribute(attributeName);
//        }

//        public bool IsElementDisplayed(By locator, int timeout = 10)
//        {
//            try
//            {
//                return SafeFindElement(locator, timeout).Displayed;
//            }
//            catch
//            {
//                return false;
//            }
//        }
//    }
//}





using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace Amazon_Application.Utilities
{
    public static class SeleniumCustomMethods
    {
        public static IWebElement GetElement(IWebDriver driver, string locator, int timeoutInSeconds = 10)
        {
            if (string.IsNullOrEmpty(locator))
                throw new ArgumentNullException(nameof(locator), "Locator value is null or empty. Check App.config key.");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            if (locator.StartsWith("id="))
                return wait.Until(d => d.FindElement(By.Id(locator.Replace("id=", ""))));
            if (locator.StartsWith("css="))
                return wait.Until(d => d.FindElement(By.CssSelector(locator.Replace("css=", ""))));
            if (locator.StartsWith("xpath="))
                return wait.Until(d => d.FindElement(By.XPath(locator.Replace("xpath=", ""))));
            if (locator.StartsWith("ClassName="))
                return wait.Until(d => d.FindElement(By.ClassName(locator.Replace("ClassName=", ""))));

            throw new Exception($"Unsupported locator: {locator}");
        }
         public static IReadOnlyCollection<IWebElement> GetElements(IWebDriver driver, string locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            if (locator.StartsWith("id="))
                return wait.Until(d => d.FindElements(By.Id(locator.Replace("id=", ""))));
            if (locator.StartsWith("css="))
                return wait.Until(d => d.FindElements(By.CssSelector(locator.Replace("css=", ""))));
            if (locator.StartsWith("xpath="))
                return wait.Until(d => d.FindElements(By.XPath(locator.Replace("xpath=", ""))));
            if (locator.StartsWith("ClassName="))
                return wait.Until(d => d.FindElements(By.ClassName(locator.Replace("ClassName=", ""))));

            throw new Exception($"Unsupported locator: {locator}");
        }
      
    }
}
