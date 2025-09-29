//using OpenQA.Selenium;
//using Amazon_Application.Utilities;

//namespace Amazon_Application_Auto.Pages
//{
//    public class LoginPage
//    {
//        private readonly IWebDriver driver;
//        private readonly SeleniumCustomMethod safe;

//        // Locators
//        private readonly By signInButton = By.Id("nav-link-accountList");
//        private readonly By emailOrMobileInput = By.Id("ap_email_login");
//        private readonly By continueButton = By.Id("continue");
//        private readonly By passwordInput = By.Id("ap_password");
//        private readonly By signInSubmit = By.Id("signInSubmit");
//        private readonly By otpInput = By.Id("cvf-input-code");
//        private readonly By whatsappOtpButton = By.Id("secondary_channel_button");

//        public LoginPage(IWebDriver driver)
//        {
//            this.driver = driver;
//            safe = new SeleniumCustomMethod(driver);
//        }

//        public void NavigateToAmazon() => driver.Navigate().GoToUrl("https://www.amazon.in/");

//        public void ClickSignIn() => safe.SafeClick(signInButton);

//        public void EnterEmailOrMobile(string input) => safe.SafeType(emailOrMobileInput, input);

//        public void ClickContinue() => safe.SafeClick(continueButton);

//        public void EnterPassword(string password) => safe.SafeType(passwordInput, password);

//        public void ClickSignInSubmit() => safe.SafeClick(signInSubmit);

//        public void EnterOtp(string otp) => safe.SafeType(otpInput, otp);

//        public void ClickWhatsappOtpOption() => safe.SafeClick(whatsappOtpButton);

//        public string GetPasswordFieldType() => safe.GetAttribute(passwordInput, "type");
//    }
//}









using Amazon_Application.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Amazon_Application.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickSignIn()
        {
            var signInBtn = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("SignInButton"));
            signInBtn.Click();
        }

        public void EnterEmail(string email)
        {
            var emailInput = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("EmailInput"));
            emailInput.Clear();
            emailInput.SendKeys(email);
        }

        public void ClickContinue()
        {
            var continueBtn = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("ContinueButton"));
            continueBtn.Click();
        }

        public void EnterMobile(string mobileNumber)
        {
            var inputField = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("EmailInput"));
            inputField.Clear();
            inputField.SendKeys(mobileNumber);
        }

        public void EnterPassword(string password)
        {
            var passwordInput = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("PasswordInput"));
            passwordInput.Clear();
            passwordInput.SendKeys(password);
        }

        public void ClickSignInSubmit()
        {
            var submitBtn = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("SignInSubmitButton"));
            submitBtn.Click();
        }

        public void ClickCreateAccount()
        {
            var createBtn = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("CreateAccountButton"));
            createBtn.Click();
        }

        public void CreateAccountSubmitButton()
        {
            var createBtn = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("CreateAccountSubmitButton"));
            createBtn.Click();
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


        //public void SelectAllSearchDropdownOptions()
        //{
        //    var dropdown = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("SearchDropdownBox"));
        //    var select = new SelectElement(dropdown);

        //    for (int i = 0; i < select.Options.Count; i++)
        //    {
        //        select.SelectByIndex(i);
        //        Console.WriteLine("Selected: " + select.Options[i].Text);
        //        Thread.Sleep(500); 
        //    }
        //}
        // Select and click each option from Search Dropdown
        public void SelectAndClickAllDropdownOptions()
        {
            var dropdown = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("SearchDropdownBox"));
            var select = new SelectElement(dropdown);

            for (int i = 0; i < select.Options.Count; i++)
            {
                select.SelectByIndex(i); // select option
                Console.WriteLine("Selected: " + select.Options[i].Text);

             
                Thread.Sleep(800);

                
                var searchButton = driver.FindElement(By.Id("nav-search-submit-button"));
                searchButton.Click();

                Thread.Sleep(1500); 
                driver.Navigate().Back(); 

               
                dropdown = SeleniumCustomMethods.GetElement(driver, ConfigReader.GetLocator("SearchDropdownBox"));
                select = new SelectElement(dropdown);
            }
        }


    }


}

