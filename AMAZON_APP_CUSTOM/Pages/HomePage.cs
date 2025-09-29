using Amazon_Application.Utilities;
using OpenQA.Selenium;

namespace Amazon_Application.Pages
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickLogo()
        {
            var logo = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("HomePageLogo"));
            logo.Click();
        }

        public void ClickDeliveryOption()
        {
            var deliveryOption = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("DeliveryOption"));
            deliveryOption.Click();
        }

        public void CloseDeliveryModal()
        {
            var closeModal = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("DeliveryCloseButton"));
            closeModal.Click();
        }
    }
}
