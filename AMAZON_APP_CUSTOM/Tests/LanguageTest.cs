using Amazon_Application.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Amazon_Application.Tests;

public class LanguageTest
{
    private IWebDriver driver;
    private HomePage homePage;
    private LoginPage loginPage;
  
    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://www.amazon.in/");
        loginPage = new LoginPage(driver);
        homePage = new HomePage(driver);
       

    }


    [Test]
    public void LoopAllLanguagesTest()
    {
        LanguagePage languagePage = new LanguagePage(driver);

        languagePage.LoopThroughAllLanguages();

        Assert.Pass("Successfully looped through and selected all available languages.");
    }

    [TearDown]
    public void Teardown()
    {
        driver.Quit();
        driver.Dispose();
    }

}
