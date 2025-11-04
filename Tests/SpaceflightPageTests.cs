using Allure.NUnit;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using SPACE_Framework.Helpers;
using SPACE_Framework.Pages;
using SPACE_Framework.Subgrids;
using SPACE_Framework.Views;
using System.Xml.Linq;
using static SPACE_Framework.TestData.TestData;

namespace SPACE_Framework.Tests
{
    [AllureNUnit]
    [AllureSuite("Spaceflight Page")]
    public class SpaceflightPageTests : BaseTest
    {
        CommonComponents? commonComponents;
        SpaceflightPage? spaceflightPage;
        SpaceflightView? view;
        Toolbar? toolbar;

        [Test]
        public void Test_Create_Spaceflight()
        {
            commonComponents = new CommonComponents(driver);
            spaceflightPage = new SpaceflightPage(driver);
            view = new SpaceflightView(driver);
            toolbar = new Toolbar(driver);

            commonComponents.NavigateToTab("Spaceflights");

            toolbar.ClickNewButton();
            spaceflightPage.FillName(spaceflightName);
            spaceflightPage.SelectSpacecraft("test");
            spaceflightPage.SelectLandingSpaceport(spaceportNY);
            spaceflightPage.SelectLaunchSpaceport(spaceportSF);
            spaceflightPage.SetStartEndDate();
            toolbar.ClickSaveAndClose();

            string recordName = view.GetRecordName("1");
            string recordLaunchSpaceport = view.GetRecordLaunchingSpaceport("1");
            string recordLandingSpaceport = view.GetRecordLandSpaceport("1");
            string recordSpacecraft = view.GetRecordSpacecraft("1");
            string recordStartDate = view.GetRecordStartDate("1");
            string recordEndDate = view.GetRecordEndDate("1");
            string recordDuration = view.GetRecordDuration("1");

            string startDate = DateTime.Today.AddDays(1).ToString("MM/dd/yyyy");
            string endDate = DateTime.Today.AddDays(2).ToString("MM/dd/yyyy");

            Assert.That(recordName, Is.EqualTo(spaceflightName));
            Assert.That(recordLaunchSpaceport, Is.EqualTo(spaceportSF));
            Assert.That(recordLandingSpaceport, Is.EqualTo(spaceportNY));
            Assert.That(recordStartDate, Is.EqualTo(startDate + " 8:00 AM"));
            Assert.That(recordEndDate, Is.EqualTo(endDate + " 8:00 AM"));
            Assert.That(recordDuration, Is.EqualTo("24.00"));
        }

         
        [Test]
        public void Test_Update_Spaceflight()
        {
            commonComponents = new CommonComponents(driver);
            spaceflightPage = new SpaceflightPage(driver);
            view = new SpaceflightView(driver);
            toolbar = new Toolbar(driver);

            commonComponents.NavigateToTab("Spaceflights");
            view.OpenActiveRecordByIndex("1");

            var random = new Random();
            string updatedName = "updatedFlight" + random.Next(1, 100);

            spaceflightPage.UpdateSpaceFlight(updatedName, spaceportNY, spaceportSF);
            toolbar.ClickSaveAndClose();

            string recordName = view.GetRecordName("1");
            string recordLaunchSpaceport = view.GetRecordLaunchingSpaceport("1");
            string recordLandingSpaceport = view.GetRecordLandSpaceport("1");

            Assert.That(recordName, Is.EqualTo(updatedName));
            Assert.That(recordLaunchSpaceport, Is.EqualTo(spaceportNY));
            Assert.That(recordLandingSpaceport, Is.EqualTo(spaceportSF)); ;
        }

        [Test]
        public void Test_Delete_Spaceflight()
        {
            commonComponents = new CommonComponents(driver);
            spaceflightPage = new SpaceflightPage(driver);
            view = new SpaceflightView(driver);

            commonComponents.NavigateToTab("Spaceflights");
            view.OpenActiveRecordByIndex("1");
            var spaceflightName = commonComponents.GetFieldValue("Name");

            commonComponents.DeleteRecord();

            var viewTitle = view.GetTabView("Active Spaceflights");
            Assert.That(viewTitle, Is.EqualTo("Active Spaceflights"));
            Assert.That(view.CheckRecordPresent(spaceflightName), Is.False, "Element should not be present on the page.");
        }

        [Test]
        public void Test()
        {
            commonComponents = new CommonComponents(driver);
            MaintenancePage maintenancePage = new MaintenancePage(driver);
            BussinessProcessFlowPage bussinessProcessFlowPage = new BussinessProcessFlowPage(driver);
          
            BaseSubgrid subgrid = new BaseSubgrid(driver);
            MaintenanceView view = new MaintenanceView(driver);

            commonComponents.NavigateToTab("Maintenances");
            view.OpenInactiveRecordsView();
            Thread.Sleep(5000);

        }
    }
}
