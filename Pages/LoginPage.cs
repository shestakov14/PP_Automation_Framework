using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPACE_Framework.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
                
        }

        public void Space_App_Login()
        {
           // driver.Navigate().GoToUrl("https://org2e4fcbdc.crm4.dynamics.com/main.aspx?appid=e7990740-a716-4c97-a822-76c0613d8de0&pagetype=entitylist&etn=space_spacecraft&viewid=9739c4a9-03b8-47f7-a040-2b2024bf838d&viewType=1039");

            // Enter username
            Thread.Sleep(2000);
            TypeOnElementByLocator(By.Id("i0116"), "alans@CRM054032.onmicrosoft.com");
            ClickElementByLocator(By.Id("idSIButton9"));

            // Enter password
            Thread.Sleep(2000);
            TypeOnElementByLocator(By.Id("i0118"), "l#tK[46TwZB^:N5]BAyIp8(e7h0+#1y3");
            ClickElementByLocator(By.Id("idSIButton9"));

            // Handle "Stay signed in?" prompt
            try
            {
                Thread.Sleep(2000);
                driver.FindElement(By.Id("idSIButton9")).Click() ;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Stay signed in prompt not shown.");
            }

            // Handle "Please sign in again" prompt
            try
            {
                driver.FindElement(By.Id("okButton_3")).Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Sign in again prompt not shown.");
            }
        }
    }
}
