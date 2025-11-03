using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SPACE_Framework.Helpers;
using static SPACE_Framework.TestData.TestData;


namespace SPACE_Framework.Pages
{
    public class SpacecraftPage: BasePage
    {
        CommonComponents CommonComponents;
        Toolbar toolbar;

        public SpacecraftPage(IWebDriver driver):base(driver)
        {
            CommonComponents = new CommonComponents(driver);
            toolbar = new Toolbar(driver);
        }

        public void FillName(string name)
        {
            CommonComponents.CompleteField("Name", name);
        }

        public void FillYear(string year)
        {
            CommonComponents.CompleteField("Year of Manufacture", year);
        }

        public void SelectCountry(string country)
        {
            CommonComponents.CompleteOptionField("Country",country);
        }

        public void SelectSpaceport(string spaceport)
        {
            CommonComponents.CompleteOptionField("Spaceport",spaceport);
        }

        public void SelectFleet(string fleet)
        {
            CommonComponents.CompleteOptionField("Fleet",fleet);
        }

        public void SelectSpacecraftModel(string spacecraftModel)
        {
            CommonComponents.CompleteOptionField("Spacecraft Model",spacecraftModel);
        }

        public void SelectOperatingCompany(string operatingCompany)
        {
            CommonComponents.CompleteOptionField("Operating Company",operatingCompany);
        }

        public void SelectOrganisationType(string index)
        {
            CommonComponents.CompleteDropdownField("Organisation Type", index);
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

        public void CreateResearchSpacecraft(string name, string year, string country, string spaceport, string fleet, string organisationTypeIndex)
        {
            FillName(name);
            FillYear(year);
            SelectCountry(country);
            SelectSpaceport(spaceport);
            SelectFleet(fleet);
            SelectSpacecraftModel(researchModel);
            SelectOrganisationType("2"); // Goverment
            toolbar.ClickSaveButton();
            toolbar.WaitUntilRecordSaved();
            toolbar.ClickSaveButton();

        }

        public void CreateMilitarySpacecraft(string name, string year, string country, string spaceport, string fleet, string armedOption)
        {
            FillName(name);
            FillYear(year);
            SelectCountry(country);
            SelectSpaceport(spaceport);
            SelectFleet(fleet);
            SelectSpacecraftModel(militaryModel);
            SetArmedOption(armedOption);
            toolbar.ClickSaveButton();
            toolbar.WaitUntilRecordSaved();
            toolbar.ClickSaveAndClose();
        }

        public void CreateCommercialSpacecraft(string name, string year, string country, string spaceport, string fleet, string operatingComapany)
        {
            FillName(name);
            FillYear(year);
            SelectCountry(country);
            SelectSpaceport(spaceport);
            SelectFleet(fleet);
            SelectSpacecraftModel(commercialModel);
            SelectOperatingCompany(operatingComapany);
            toolbar.ClickSaveButton();
            toolbar.WaitUntilRecordSaved();
            toolbar.ClickSaveAndClose();
        }
    } 
}
