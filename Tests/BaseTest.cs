using Allure.Net.Commons;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using SPACE_Framework.Pages;

namespace SPACE_Framework.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        LoginPage? loginPage;
        const string SpaceAppURL = "https://org2e4fcbdc.crm4.dynamics.com/main.aspx?appid=e7990740-a716-4c97-a822-76c0613d8de0&pagetype=entitylist&etn=space_spacecraft&viewid=9739c4a9-03b8-47f7-a040-2b2024bf838d&viewType=1039";

        [SetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--headless=new");
            //chromeOptions.AddArgument("--incognito");
            chromeOptions.AddArgument("--start-maximized");
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.AddArgument("--ignore-certificate-errors");
            chromeOptions.AddArgument("--disable-dev-shm-usage");

            //bypassing MS login pages
            chromeOptions.AddArguments(@"user-data-dir=C:\SeleniumProfiles\PowerApps");
            chromeOptions.AddArguments("--profile-directory=Profile 1");
           
            driver = new ChromeDriver(chromeOptions);
            driver.Navigate().GoToUrl(SpaceAppURL);
            //loginPage = new LoginPage(driver);
            //loginPage.Space_App_Login(); 
        }


        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}