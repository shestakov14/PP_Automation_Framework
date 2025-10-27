using OpenQA.Selenium;
using SPACE_Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPACE_Framework.Pages
{
    public class SpaceflightPage : BasePage
    {
        CommonComponents CommonComps;
        public SpaceflightPage(IWebDriver driver) : base(driver)
        {
            CommonComps = new CommonComponents(driver);
        }

        public void FillName(string spaceflightName)
        {
            CommonComps.CompleteField("Name", spaceflightName);
        }

        public void SelectSpacecraft(string spacecraft)
        {
            CommonComps.CompleteOptionField("Spacecraft", spacecraft);
        }

        public void SelectLaunchSpaceport(string spaceport)
        {
            CommonComps.CompleteOptionField("Launch Spaceport", spaceport);
        }

        public void SelectLandingSpaceport(string spaceport)
        {
            CommonComps.CompleteOptionField("Landing Spaceport", spaceport);
        }

        public void SetStartEndDate()
        {
            DateTime tomorrow = DateTime.Today.AddDays(1);
            string formattedStartDate = tomorrow.ToString("MM-dd-yyyy");

            DateTime dayAfterTomorrow = tomorrow.AddDays(1);
            string formattedEndDate = dayAfterTomorrow.ToString("MM-dd-yyyy");

            CommonComps.CompleteField("Date of Start Date/Time", formattedStartDate);
            CommonComps.CompleteField("Date of End Date/Time", formattedEndDate);
        }

        public void UpdateSpaceFlight(string name, string launchSpaceport, string landingSpaceport) 
        {
            ClearElementTextByLocator(By.XPath("//input[@aria-label=\"Name\"]"));
            var random = new Random();
            name = name + random.Next(1, 100);
            CommonComps.CompleteField("Name", name);
            CommonComps.UpdateOptionFieldValue("Landing Spaceport", landingSpaceport);
            CommonComps.UpdateOptionFieldValue("Launch Spaceport", launchSpaceport);
        }
        public string GetRecordName()
        {
            var locator = By.XPath("//input[@aria-label=\"Name\"]");
            string value = FindElementByLocator(locator).GetAttribute("value");
            return value;
        }
    }
}
