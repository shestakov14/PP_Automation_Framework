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
        CommonComponents commonComponents;
        public SpaceflightPage(IWebDriver driver) : base(driver)
        {
            commonComponents = new CommonComponents(driver);
        }

        public void FillName(string spaceflightName)
        {
            commonComponents.CompleteField("Name", spaceflightName);
        }

        public void SelectSpacecraft(string spacecraft)
        {
            commonComponents.CompleteOptionField("Spacecraft", spacecraft);
        }

        public void SelectLaunchSpaceport(string spaceport)
        {
            commonComponents.CompleteOptionField("Launch Spaceport", spaceport);
        }

        public void SelectLandingSpaceport(string spaceport)
        {
            commonComponents.CompleteOptionField("Landing Spaceport", spaceport);
        }

        public void SetStartEndDate()
        {
            string tomorrow = DateTime.Today.AddDays(1).ToString("MM/dd/yyyy");
            string dayAfterTomorrow = DateTime.Today.AddDays(2).ToString("MM/dd/yyyy");

            commonComponents.CompleteField("Date of Start Date/Time", tomorrow);
            commonComponents.CompleteField("Date of End Date/Time", dayAfterTomorrow);
        }

        public void UpdateSpaceFlight(string name, string launchSpaceport, string landingSpaceport) 
        {
            ClearElementTextByLocator(By.XPath("//input[@aria-label=\"Name\"]"));
            commonComponents.CompleteField("Name", name);
            commonComponents.UpdateOptionFieldValue("Landing Spaceport", landingSpaceport);
            commonComponents.UpdateOptionFieldValue("Launch Spaceport", launchSpaceport);
        }
    }
}
