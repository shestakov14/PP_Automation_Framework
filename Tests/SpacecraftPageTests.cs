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
        SpacecraftView? view;

        [Test]
        public void Test_Create_CommercialModelSpacecraft()
        {
            commonComponents = new CommonComponents(driver);
            spacecraftPage = new SpacecraftPage(driver);
            view = new SpacecraftView(driver);

            commonComponents.ClickNewButtonFromToolbar();

            spacecraftPage.FillName(commercialSpacecraftName);
            spacecraftPage.FillYear(yearManufacture);
            spacecraftPage.SelectCountry(countryBG);
            spacecraftPage.SelectSpaceport(spaceportSF);
            spacecraftPage.SelectFleet("Commercial Fleet");
            spacecraftPage.SelectSpacecraftModel("Commercial Model");
            spacecraftPage.SelectOperatingCompany("SPACE");

            commonComponents.ClickSaveAndCloseButtonFromToolbar();

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
            Assert.That(recordModel, Is.EqualTo("Commercial Model"));
            Assert.That(recordSpaceport, Is.EqualTo(spaceportSF));
            Assert.That(recordFleet, Is.EqualTo("Commercial Fleet"));
            Assert.That(recordHours, Is.EqualTo(""));
            Assert.IsTrue(isMatch, regNumber);
        }


        [Test]
        public void Test_Create_MilitaryModelSpacecraft()
        {
            commonComponents = new CommonComponents(driver);
            spacecraftPage = new SpacecraftPage(driver);
            view = new SpacecraftView(driver);

            commonComponents.ClickNewButtonFromToolbar();

            spacecraftPage.FillName(militarySpacecraftName);
            spacecraftPage.FillYear(yearManufacture);
            spacecraftPage.SelectCountry(countryAU);
            spacecraftPage.SelectSpaceport(spaceportSY);
            spacecraftPage.SelectFleet("Military Fleet");
            spacecraftPage.SelectSpacecraftModel("Military model");
            spacecraftPage.SetArmedOption("Yes");

            commonComponents.ClickSaveAndCloseButtonFromToolbar();

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
            Assert.That(recordModel, Is.EqualTo("Military Model"));
            Assert.That(recordSpaceport, Is.EqualTo(spaceportSY));
            Assert.That(recordFleet, Is.EqualTo("Military Fleet"));
            Assert.That(recordHours, Is.EqualTo(""));
            Assert.IsTrue(isMatch, regNumber);
        }

        [Test]
        public void Test_Create_ResearchModelSpacecraft()
        {
            commonComponents = new CommonComponents(driver);
            spacecraftPage = new SpacecraftPage(driver); ;
            view = new SpacecraftView(driver);

            commonComponents.ClickNewButtonFromToolbar();

            spacecraftPage.FillName(researchSpacecraftName);
            spacecraftPage.FillYear(yearManufacture);
            spacecraftPage.SelectCountry(countryUS);
            spacecraftPage.SelectSpaceport(spaceportNY);
            spacecraftPage.SelectFleet("Research Fleet");
            spacecraftPage.SelectSpacecraftModel("Research model");
            spacecraftPage.SelectOrganisationType("2");

            commonComponents.ClickSaveAndCloseButtonFromToolbar();

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
            Assert.That(recordModel, Is.EqualTo("Research Model"));
            Assert.That(recordSpaceport, Is.EqualTo(spaceportNY));
            Assert.That(recordFleet, Is.EqualTo("Research Fleet"));
            Assert.That(recordHours, Is.EqualTo(""));
            Assert.IsTrue(isMatch, regNumber);
        }

        [Test]
        public void Test_Edit_ActiveSpacecraft()
        {
            commonComponents = new CommonComponents(driver);
            spacecraftPage = new SpacecraftPage(driver);
            view = new SpacecraftView(driver);

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
            view = new SpacecraftView(driver);

            view.OpenActiveRecordByIndex("1");
            commonComponents.DeleteRecord();

            var viewTitle = view.GetTabView("Active Spacecrafts");
            Assert.That(viewTitle, Is.EqualTo("Active Spacecrafts"));
        }
    }
}
