using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPACE_Framework.Views
{
    public class SpacecraftView : BaseView
    {
        public SpacecraftView(IWebDriver driver) : base(driver)
        {
        }

        public string GetRecordRegistrationNumber(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_registrationnumber')])[{index}]//label[@aria-label]");
            var recordRegNumber = FindElementByLocator(locator);

            return recordRegNumber.GetAttribute("aria-label");
        }

        public string GetRecordYear(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_yearofmanufacture')])[{index}]//label[@aria-label]");
            var recordYear = FindElementByLocator(locator);

            return recordYear.GetAttribute("aria-label");
        }

        public string GetRecordStatus(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_statuscode')])[{index}]//label[@aria-label]");
            var recordStatus = FindElementByLocator(locator);

            return recordStatus.GetAttribute("aria-label");
        }

        public string GetRecordFlightHours(string index) 
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_totalflighthours')])[{index}]//label[@aria-label]");
            var recordHours = FindElementByLocator(locator);

            return recordHours.GetAttribute("aria-label");
        }
       
        public string GetRecordModel(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_spacecraftmodelid')])[{index}]//a[@href]");
            var recordModel = FindElementByLocator(locator);

            return recordModel.GetAttribute("aria-label");
        }

        public string GetRecordSpaceport(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_spaceport')])[{index}]//a[@href]");
            var recordSpaceport = FindElementByLocator(locator);

            return recordSpaceport.GetAttribute("aria-label");
        }

        public string GetRecordFleet(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_fleet')])[{index}]//a[@href]");
            var recordFleet = FindElementByLocator(locator);

            return recordFleet.GetAttribute("aria-label");
        }
    }
}
