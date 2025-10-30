using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPACE_Framework.Views
{
    public class SpaceflightView : BaseView
    {
        public SpaceflightView(IWebDriver driver) : base(driver)
        {
        }

        public string GetRecordLaunchingSpaceport(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_launchspaceportid')])[{index}]//a[@href]");
            var recordLaunchSpaceport = FindElementByLocator(locator);

            return recordLaunchSpaceport.GetAttribute("aria-label");
        }

        public string GetRecordLandSpaceport(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_landingspaceportid')])[{index}]//a[@href]");
            var recordLandingSpaceport = FindElementByLocator(locator);

            return recordLandingSpaceport.GetAttribute("aria-label");
        }

        public string GetRecordSpacecraft(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_spacecraftid')])[{index}]//a[@href]");
            var recordLandingSpaceport = FindElementByLocator(locator);

            return recordLandingSpaceport.GetAttribute("aria-label");
        }

        public string GetRecordStartDate(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_startdatetime')])[{index}]//label[@aria-label]");
            var recordStartDate = FindElementByLocator(locator);

            return recordStartDate.GetAttribute("aria-label");
        }

        public string GetRecordEndDate(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_enddatetime')])[{index}]//label[@aria-label]");
            var recordEndDate = FindElementByLocator(locator);

            return recordEndDate.GetAttribute("aria-label");
        }

        public string GetRecordDuration(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_duration')])[{index}]//label[@aria-label]");
            var recordDuration = FindElementByLocator(locator);

            return recordDuration.GetAttribute("aria-label");
        }


        public bool CheckRecordPresent(string spaceflightName)
        {
            var locator = By.XPath($"(//div[@role='row'][1]//a[contains(@aria-label, '{spaceflightName}')])[1]");
            bool result = IsElementVisible(locator);
            return result;
        }
    }
}
 