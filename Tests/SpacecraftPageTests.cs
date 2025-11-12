using Allure.NUnit;
using Allure.NUnit.Attributes;
using SPACE_Framework.Helpers;
using SPACE_Framework.Pages;
using SPACE_Framework.QuickCreatePages;
using SPACE_Framework.Subgrids;
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
        SpacecraftView? view;
        Toolbar? toolbar;
        EnginePage? enginePage;
        BaseSubgrid? subgrid;
        EngineQuickCreatePage? engineQuickCreatePage;

        [Test]
        public void Test_Create_CommercialModelSpacecraft()
        {
            commonComponents = new CommonComponents(driver);
            spacecraftPage = new SpacecraftPage(driver);
            view = new SpacecraftView(driver);
            toolbar = new Toolbar(driver);

            toolbar.ClickNewButton();

            spacecraftPage.FillName(commercialSpacecraftName);
            spacecraftPage.FillYear(yearManufacture);
            spacecraftPage.SelectCountry(countryBG);
            spacecraftPage.SelectSpaceport(spaceportSF);
            spacecraftPage.SelectFleet(commercialFleet);
            spacecraftPage.SelectSpacecraftModel(commercialModel);
            spacecraftPage.SelectOperatingCompany("SPACE Enterprice");

            toolbar.ClickSaveAndClose();

            string regNumber = view.GetRecordRegistrationNumber("1");
            string recordName = view.GetRecordName("1");
            string recordYear = view.GetRecordYear("1");
            string recordStatus = view.GetRecordStatus("1");
            string recordModel = view.GetRecordModel("1");
            string recordSpaceport = view.GetRecordSpaceport("1");
            string recordFleet = view.GetRecordFleet("1"); 
            string recordHours = view.GetRecordFlightHours("1");

            string pattern = @"^BG-[A-Z0-9]{3,4}$";
            bool isMatch = Regex.IsMatch(regNumber, pattern);

            Assert.That(recordName, Is.EqualTo(commercialSpacecraftName));
            Assert.That(recordYear, Is.EqualTo(yearManufacture));
            Assert.That(recordStatus, Is.EqualTo("Stationed"));
            Assert.That(recordModel, Is.EqualTo(commercialModel));
            Assert.That(recordSpaceport, Is.EqualTo(spaceportSF));
            Assert.That(recordFleet, Is.EqualTo(commercialFleet));
            Assert.That(recordHours, Is.EqualTo(""));
            Assert.IsTrue(isMatch, regNumber);
        }


        [Test]
        public void Test_Create_MilitaryModelSpacecraft()
        {
            commonComponents = new CommonComponents(driver);
            spacecraftPage = new SpacecraftPage(driver);
            view = new SpacecraftView(driver);
            toolbar = new Toolbar(driver);

            toolbar.ClickNewButton();

            spacecraftPage.FillName(militarySpacecraftName);
            spacecraftPage.FillYear(yearManufacture);
            spacecraftPage.SelectCountry(countryAU);
            spacecraftPage.SelectSpaceport(spaceportSY);
            spacecraftPage.SelectFleet(militaryFleet);
            spacecraftPage.SelectSpacecraftModel(militaryModel);
            spacecraftPage.SetArmedOption("Yes");

            toolbar.ClickSaveAndClose();

            string regNumber = view.GetRecordRegistrationNumber("1");
            string recordName = view.GetRecordName("1");
            string recordYear = view.GetRecordYear("1");
            string recordStatus = view.GetRecordStatus("1");
            string recordModel = view.GetRecordModel("1");
            string recordSpaceport = view.GetRecordSpaceport("1");
            string recordFleet = view.GetRecordFleet("1");
            string recordHours = view.GetRecordFlightHours("1");

            string pattern = @"^AU-[A-Z0-9]{3,4}$";
            bool isMatch = Regex.IsMatch(regNumber, pattern);

            Assert.That(recordName, Is.EqualTo(militarySpacecraftName));
            Assert.That(recordYear, Is.EqualTo(yearManufacture));
            Assert.That(recordStatus, Is.EqualTo("Stationed"));
            Assert.That(recordModel, Is.EqualTo(militaryModel));
            Assert.That(recordSpaceport, Is.EqualTo(spaceportSY));
            Assert.That(recordFleet, Is.EqualTo(militaryFleet));
            Assert.That(recordHours, Is.EqualTo(""));
            Assert.IsTrue(isMatch, regNumber);
        }

        [Test]
        public void Test_Create_ResearchModelSpacecraft()
        {
            commonComponents = new CommonComponents(driver);
            spacecraftPage = new SpacecraftPage(driver); ;
            view = new SpacecraftView(driver);
            toolbar = new Toolbar(driver);

            toolbar.ClickNewButton();

            spacecraftPage.FillName(researchSpacecraftName);
            spacecraftPage.FillYear(yearManufacture);
            spacecraftPage.SelectCountry(countryUS);
            spacecraftPage.SelectSpaceport(spaceportNY);
            spacecraftPage.SelectFleet(researchFleet);
            spacecraftPage.SelectSpacecraftModel(researchModel);
            spacecraftPage.SelectOrganisationType("2");

            toolbar.ClickSaveAndClose();

            string regNumber = view.GetRecordRegistrationNumber("1");
            string recordName = view.GetRecordName("1");
            string recordYear = view.GetRecordYear("1");
            string recordStatus = view.GetRecordStatus("1");
            string recordModel = view.GetRecordModel("1");
            string recordSpaceport = view.GetRecordSpaceport("1");
            string recordFleet = view.GetRecordFleet("1");
            string recordHours = view.GetRecordFlightHours("1");

            string pattern = @"^US-[A-Z0-9]{3,4}$";
            bool isMatch = Regex.IsMatch(regNumber, pattern);

            Assert.That(recordName, Is.EqualTo(researchSpacecraftName));
            Assert.That(recordYear, Is.EqualTo(yearManufacture));
            Assert.That(recordStatus, Is.EqualTo("Stationed"));
            Assert.That(recordModel, Is.EqualTo(researchModel));
            Assert.That(recordSpaceport, Is.EqualTo(spaceportNY));
            Assert.That(recordFleet, Is.EqualTo(researchFleet));
            Assert.That(recordHours, Is.EqualTo(""));
            Assert.IsTrue(isMatch, regNumber);
        }

        [Test]
        public void Test_Edit_ActiveSpacecraft()
        {
            commonComponents = new CommonComponents(driver);
            spacecraftPage = new SpacecraftPage(driver);
            view = new SpacecraftView(driver);
            toolbar = new Toolbar(driver);

            view.OpenActiveRecordByName(militarySpacecraftName);
            var title = commonComponents.GetRecordTitle();

            Assert.That(title, Is.EqualTo(militarySpacecraftName));

            commonComponents.UpdateOptionFieldValue("Country", countryBG);
            commonComponents.UpdateOptionFieldValue("Spaceport", spaceportSF);
            toolbar.ClickSaveButton();

            string regNumber = commonComponents.GetFieldValue("Registration Number");
            string pattern = @"^BG-[A-Z0-9]{3,4}$";
            bool isMatch = Regex.IsMatch(regNumber, pattern);
            Assert.IsTrue(isMatch);
        }

        [Test]
        public void Test_Delete_ActiveSpacecraft()
        {
            commonComponents = new CommonComponents(driver);
            spacecraftPage = new SpacecraftPage(driver);
            view = new SpacecraftView(driver);

            view.OpenActiveRecordByIndex("1");
            commonComponents.DeleteRecord();

            var viewTitle = view.GetTabView("Active Spacecrafts");
            Assert.That(viewTitle, Is.EqualTo("Active Spacecrafts"));
        }

        [Test]
        public void Test_AddMoreEngines_ThanEngineCount()
        {
            commonComponents = new CommonComponents(driver);
            spacecraftPage = new SpacecraftPage(driver);
            view = new SpacecraftView(driver);
            toolbar = new Toolbar(driver);
            enginePage = new EnginePage(driver);
            subgrid = new BaseSubgrid(driver);
            engineQuickCreatePage = new EngineQuickCreatePage(driver);

            toolbar.ClickNewButton();
            spacecraftPage.CreateCommercialSpacecraft("SPACE Enterprice");
            enginePage.FillName(engineName);
            enginePage.SelectEngineModel("Hyperion 7");
            toolbar.ClickSaveAndClose();
            subgrid.NavigateToSubgridSection("Engine");
            subgrid.ClickNewButton("Engine");
            engineQuickCreatePage.CreateEngineRecord(engineName,commercialModel);



        }
    }
}
