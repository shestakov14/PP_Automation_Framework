using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPACE_Framework.Views
{
    public class MaintenanceView : BaseView
    {
        public MaintenanceView(IWebDriver driver) : base(driver)
        {
        }

        public void OpenInactiveRecordsView()
        {
            var activeButtonLocator = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@aria-label=\"Active Maintenances\"]")));
            activeButtonLocator.Click();
            var inactiveButtonLocator = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(@class, ms-button)]//label[text()='Inactive Maintenances']")));
            inactiveButtonLocator.Click();
        }
    }
}
 