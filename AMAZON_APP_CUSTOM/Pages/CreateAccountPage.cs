//using OpenQA.Selenium;
//using Amazon_Application.Utilities;

//namespace Amazon_Application_Auto.Pages
//{
//    public class CreateAccountPage
//    {
//        private readonly IWebDriver driver;
//        private readonly SeleniumCustomMethod safe;

//        private readonly By createAccountButton = By.Id("createAccountSubmit");
//        private readonly By mobileNumber = By.Id("ap_phone_number");
//        private readonly By customerName = By.Id("ap_customer_name");
//        private readonly By password = By.Id("ap_password");
//        private readonly By continueButton = By.Id("continue");

//        public CreateAccountPage(IWebDriver driver)
//        {
//            this.driver = driver;
//            safe = new SeleniumCustomMethod(driver);
//        }

//        public void ClickCreateAccount() => safe.SafeClick(createAccountButton);

//        public void EnterMobileNumber(string mobile) => safe.SafeType(mobileNumber, mobile);

//        public void EnterCustomerName(string name) => safe.SafeType(customerName, name);

//        public void EnterPassword(string pass) => safe.SafeType(password, pass);

//        public void ClickContinue() => safe.SafeClick(continueButton);

//        public void FillAllFields(string mobile, string name, string pass)
//        {
//            EnterMobileNumber(mobile);
//            EnterCustomerName(name);
//            EnterPassword(pass);
//            ClickContinue();
//        }
//    }
//}






using OpenQA.Selenium;
using Amazon_Application.Utilities;

namespace Amazon_Application.Pages
{
    public class CreateAccountPage
    {
        private IWebDriver driver;

        public CreateAccountPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnterName(string name)
        {
            var nameInput = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("CreateAccountName"));
            nameInput.Clear();
            nameInput.SendKeys(name);
        }

        public void EnterMobile(string mobile)
        {
            var mobileInput = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("CreateAccountMobile"));
            mobileInput.Clear();
            mobileInput.SendKeys(mobile);
        }

        public void EnterPassword(string password)
        {
            var passwordInput = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("CreateAccountPassword"));
            passwordInput.Clear();
            passwordInput.SendKeys(password);
        }

        public void ClickSubmit()
        {
            var submitBtn = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("CreateAccountSubmitButton"));
            submitBtn.Click();
        }
    }
}
