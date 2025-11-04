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

        public void CreateResearchSpacecraft()
        {
            FillName(researchSpacecraftName);
            FillYear(yearManufacture);
            SelectCountry(countryAU);
            SelectSpaceport(spaceportSY);
            SelectFleet(researchFleet);
            SelectSpacecraftModel(researchModel);
            SelectOrganisationType("2"); // Goverment
            toolbar.ClickSaveButton();
            toolbar.WaitUntilRecordSaved();
            toolbar.ClickSaveButton();

        }

        public void CreateMilitarySpacecraft(string armedOption)
        {
            FillName(militarySpacecraftName);
            FillYear(yearManufacture);
            SelectCountry(countryUS);
            SelectSpaceport(spaceportNY);
            SelectFleet(militaryFleet);
            SelectSpacecraftModel(militaryModel);
            SetArmedOption(armedOption);
            toolbar.ClickSaveButton();
            toolbar.WaitUntilRecordSaved();
            toolbar.ClickSaveAndClose();
        }

        public void CreateCommercialSpacecraft(string operatingComapany)
        {
            FillName(commercialSpacecraftName);
            FillYear(yearManufacture);
            SelectCountry(countryBG);
            SelectSpaceport(spaceportSF);
            SelectFleet(commercialFleet);
            SelectSpacecraftModel(commercialModel);
            SelectOperatingCompany(operatingComapany);
            toolbar.ClickSaveButton();
            toolbar.WaitUntilRecordSaved();
            toolbar.ClickSaveAndClose();
        }
    } 
}
