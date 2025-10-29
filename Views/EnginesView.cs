using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPACE_Framework.Views
{
    public class EnginesView : BaseView
    {
        public EnginesView(IWebDriver driver) : base(driver)
        {
        }

        public string GetEngineLeaseValue(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'enginelease')])[{index}]//label[@aria-label]");
            var recordValue = FindElementByLocator(locator);

            return recordValue.GetAttribute("aria-label");
        }

        public string GetRecordStatus(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_status')])[{index}]//label[@aria-label]");
            var recordStatus = FindElementByLocator(locator);

            return recordStatus.GetAttribute("aria-label");
        }

        public string GetRecordModel(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_enginemodel')])[{index}]//a[@href]");
            var recordModel = FindElementByLocator(locator);

            return recordModel.GetAttribute("aria-label");
        }

        public string GetRecordSpacecraft(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_spacecraft')])[{index}]//a[@href]");
            var recordSpacecraft = FindElementByLocator(locator);

            return recordSpacecraft.GetAttribute("aria-label");
        }
    }
}
