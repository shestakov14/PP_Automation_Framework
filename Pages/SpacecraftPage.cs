using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SPACE_Framework.Helpers;
using static SPACE_Framework.TestData.TestData;


namespace SPACE_Framework.Pages
{
    public class SpacecraftPage: BasePage
    {
        CommonComponents CommonComps;

        public SpacecraftPage(IWebDriver driver):base(driver)
        {
            CommonComps = new CommonComponents(driver);
        }

        public void FillName(string name)
        {
            CommonComps.CompleteField("Name", name);
        }

        public void FillYear(string year)
        {
            CommonComps.CompleteField("Year of Manufacture", year);
        }

        public void SelectCountry(string country)
        {
            CommonComps.CompleteOptionField("Country",country);
        }

        public void SelectSpaceport(string spaceport)
        {
            CommonComps.CompleteOptionField("Spaceport",spaceport);
        }

        public void SelectFleet(string fleet)
        {
            CommonComps.CompleteOptionField("Fleet",fleet);
        }

        public void SelectSpacecraftModel(string spacecraftModel)
        {
            CommonComps.CompleteOptionField("Spacecraft Model",spacecraftModel);
        }

        public void SelectOperatingCompany(string operatingCompany)
        {
            CommonComps.CompleteOptionField("Operating Company",operatingCompany);
        }

        public void SelectOrganisationType(string index)
        {
            CommonComps.CompleteDropdownField("Organisation Type", index);
        }


        public void SetArmedOption(string desiredOption)
        {
            if (desiredOption == "No") 
            {
                ClickElementByLocator(By.XPath("//button[@id=\"toggle-button\"]"));
            }
            if (desiredOption == "Yes")
            {
                var toggle = By.XPath("//input[contains(@aria-label, 'Is Armed?: Required:')]");
                ClickElementByLocator(By.XPath("//button[@id=\"toggle-button\"]"));
                ClickElementByLocator(toggle);
            }
        }
        
        public string GetRegistrationNumber()
        {
            var locator = By.XPath("//input[@aria-label=\"Registration Number\"]");
            string value = FindElementByLocator(locator).GetAttribute("value");
            return value;
        }
    } 
}
