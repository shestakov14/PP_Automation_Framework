using Allure.NUnit;
using Allure.NUnit.Attributes;
using SPACE_Framework.Helpers;
using SPACE_Framework.Pages;
using SPACE_Framework.Views;
using System.Text.RegularExpressions;
using static SPACE_Framework.TestData.TestData;

namespace SPACE_Framework.Tests
{
    [AllureNUnit]
    [AllureSuite("Spacecraft Page")]
    public class SpacecraftPageTests : BaseTest
    {
        CommonComponents? commonComponents;
        SpacecraftPage? spacecraftPage;
        BaseView? view;

        [Test]
        public void Test_Create_CommercialModelSpacecraft()
        {
            commonComponents = new CommonComponents(driver);
            spacecraftPage = new SpacecraftPage(driver);

            commonComponents.ClickNewButtonFromToolbar();

            spacecraftPage.FillName(commercialSpacecraftName);
            spacecraftPage.FillYear();
            spacecraftPage.SelectCountry(countryBG);
            spacecraftPage.SelectSpaceport(spaceportSF);
            spacecraftPage.SelectFleet("Commercial Fleet");
            spacecraftPage.SelectSpacecraftModel("Commercial model");
            spacecraftPage.SelectOperatingCompany("SPACE");

            commonComponents.ClickSaveButtonFromToolbar();

            string regNumber = spacecraftPage.GetRegistrationNumber();
            string pattern = @"^BG-[A-Z0-9]{3,4}$";
            bool isMatch = Regex.IsMatch(regNumber, pattern);
            Assert.IsTrue(isMatch, regNumber);
        }


        [Test]
        public void Test_Create_MilitaryModelSpacecraft()
        {
            commonComponents = new CommonComponents(driver);
            spacecraftPage = new SpacecraftPage(driver);

            commonComponents.ClickNewButtonFromToolbar();

            spacecraftPage.FillName(militarySpacecraftName);
            spacecraftPage.FillYear();
            spacecraftPage.SelectCountry(countryAU);
            spacecraftPage.SelectSpaceport(spaceportSY);
            spacecraftPage.SelectFleet("Military Fleet");
            spacecraftPage.SelectSpacecraftModel("Military model");
            spacecraftPage.SetArmedOption("Yes");

            commonComponents.ClickSaveButtonFromToolbar();

            string regNumber = spacecraftPage.GetRegistrationNumber();
            string pattern = @"^AU-[A-Z0-9]{3,4}$";
            bool isMatch = Regex.IsMatch(regNumber, pattern);
            Assert.IsTrue(isMatch);
        }

        [Test]
        public void Test_Create_ResearchModelSpacecraft()
        {
            commonComponents = new CommonComponents(driver);
            spacecraftPage = new SpacecraftPage(driver); ;

            commonComponents.ClickNewButtonFromToolbar();

            spacecraftPage.FillName(researchSpacecraftName);
            spacecraftPage.FillYear();
            spacecraftPage.SelectCountry(countryUS);
            spacecraftPage.SelectSpaceport(spaceportNY);
            spacecraftPage.SelectFleet("Research Fleet");
            spacecraftPage.SelectSpacecraftModel("Research model");
            spacecraftPage.SelectOrganisationType("2");

            commonComponents.ClickSaveButtonFromToolbar();

            string regNumber = spacecraftPage.GetRegistrationNumber();
            string pattern = @"^US-[A-Z0-9]{3,4}$";
            bool isMatch = Regex.IsMatch(regNumber, pattern);
            Assert.IsTrue(isMatch);
        }

        [Test]
        public void Test_Edit_ActiveSpacecraft()
        {
            commonComponents = new CommonComponents(driver);
            spacecraftPage = new SpacecraftPage(driver);
            view = new BaseView(driver);

            view.OpenActiveRecordByName(militarySpacecraftName);
            var title = commonComponents.GetRecordTitle();

            Assert.That(title, Is.EqualTo(militarySpacecraftName));

            commonComponents.UpdateOptionFieldValue("Country", countryBG);
            commonComponents.UpdateOptionFieldValue("Spaceport", spaceportSF);
            commonComponents.ClickSaveButtonFromToolbar();

            string regNumber = spacecraftPage.GetRegistrationNumber();
            string pattern = @"^BG-[A-Z0-9]{3,4}$";
            bool isMatch = Regex.IsMatch(regNumber, pattern);
            Assert.IsTrue(isMatch);
        }

        [Test]
        public void Test_Delete_ActiveSpacecraft()
        {
            commonComponents = new CommonComponents(driver);
            spacecraftPage = new SpacecraftPage(driver);
            view = new BaseView(driver);

            view.OpenActiveRecordByName(commercialSpacecraftName);
            commonComponents.DeleteRecord();

            var viewTitle = view.GetTabView("Active Spacecrafts");
            Assert.That(viewTitle, Is.EqualTo("Active Spacecrafts"));
            
        }
    }
}
