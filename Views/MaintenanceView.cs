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

        public string GetRecordDiagnostic(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_diagnosticrequired')])[{index}]//label[@aria-label]");
            var recordDiagnostic = FindElementByLocator(locator);

            return recordDiagnostic.GetAttribute("aria-label");
        }

        public string GetRecordRepair(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_immediaterepair')])[{index}]//label[@aria-label]");
            var recordRepair = FindElementByLocator(locator);

            return recordRepair.GetAttribute("aria-label");
        }

        public string GetRecordSeverity(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_severitycode')])[{index}]//label[@aria-label]");
            var recordSeverity = FindElementByLocator(locator);

            return recordSeverity.GetAttribute("aria-label");
        }

        public string GetRecordCompletionDate(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_actualcompletiondate')])[1]//label[@aria-label]");
            var recordCompletionDate = FindElementByLocator(locator);

            return recordCompletionDate.GetAttribute("aria-label");
        }
        public string GetRecordAssignedTo(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_assignedtoid')])[{index}]//button");
            var recordAssignedTo = FindElementByLocator(locator);

            return recordAssignedTo.GetAttribute("aria-label");
        }
    }
}
 