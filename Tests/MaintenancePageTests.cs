using Allure.NUnit;
using Allure.NUnit.Attributes;
using SPACE_Framework.Helpers;
using SPACE_Framework.Pages;
using SPACE_Framework.QuickCreatePages;
using SPACE_Framework.Subgrids;
using SPACE_Framework.Views;
using static SPACE_Framework.TestData.TestData;

namespace SPACE_Framework.Tests
{
    [AllureNUnit]
    [AllureSuite("Maintenance Page")]
    public class MaintenancePageTests : BaseTest
    {
        CommonComponents? commonComponents;
        MaintenancePage? maintenancePage;
        BussinessProcessFlowPage? bussinessProcessFlowPage;
        MaintenanceView? view;
        BaseSubgrid? subgrid;
        Toolbar? toolbar;
        BaseQuickCreatePage? quickCreatePage;

        [Test]
        public void Test_CreateMaintenanceRecord() 
        {
            commonComponents = new CommonComponents(driver);
            maintenancePage = new MaintenancePage(driver);
            bussinessProcessFlowPage = new BussinessProcessFlowPage(driver);
            view = new MaintenanceView(driver);
            subgrid = new BaseSubgrid(driver);
            toolbar = new Toolbar(driver);
            quickCreatePage = new BaseQuickCreatePage(driver);

            commonComponents.NavigateToTab("Maintenances");
            toolbar.ClickNewButton();
            maintenancePage.CreteMaintenanceRecord(maintenanceName, "demo", "BAP", "Engine Overheating");
            view.OpenInactiveRecordsView();
            view.RefreshUntilViewRowsCountUpdated();

            string recordName = view.GetRecordName("1");
            string recordComletionDate = view.GetRecordCompletionDate("1");
            string recordAssigne = view.GetRecordAssignedTo("1");
            string recordDiagnostic = view.GetRecordDiagnostic("1");
            string recordRepair = view.GetRecordRepair("1");
            string recordSeverity = view.GetRecordSeverity("1");
            string completionDate = DateTime.Today.ToString("MM/d/yyyy");

            Assert.That(recordName, Is.EqualTo(maintenanceName));
            Assert.That(recordComletionDate, Is.EqualTo(completionDate));
            Assert.That(recordAssigne, Is.EqualTo("# BAP"));
            Assert.That(recordDiagnostic, Is.EqualTo("No"));
            Assert.That(recordRepair, Is.EqualTo("No"));
            Assert.That(recordSeverity, Is.EqualTo(""));
        }

        [Test]
        public void Test_DeleteMaintenanceRecord()
        {
            commonComponents = new CommonComponents(driver);
            maintenancePage = new MaintenancePage(driver);
            bussinessProcessFlowPage = new BussinessProcessFlowPage(driver);
            view = new MaintenanceView(driver);
            subgrid = new BaseSubgrid(driver);

            commonComponents.NavigateToTab("Maintenances");
            view.OpenActiveRecordByIndex("1");
            commonComponents.DeleteRecord();

            Assert.That(view.GetTabView("Maintenances"), Is.EqualTo("Active Maintenances"));
        }

        [Test]
        public void Test_CompleteMaintenance_WithPendingTasks()
        {
            commonComponents = new CommonComponents(driver); 
            maintenancePage = new MaintenancePage(driver);
            bussinessProcessFlowPage = new BussinessProcessFlowPage(driver);
            view = new MaintenanceView(driver);
            subgrid = new BaseSubgrid(driver);
            toolbar = new Toolbar(driver);
            quickCreatePage = new BaseQuickCreatePage(driver);

            commonComponents.NavigateToTab("Maintenances");
            toolbar.ClickNewButton();
            maintenancePage.FillName("Pending Tasks Record");
            maintenancePage.SelectSpacecraft("Demo");
            toolbar.ClickSaveButton();

            subgrid.NavigateToSubgridSection("Triage");
            commonComponents.CompleteOptionField("Assigned To", "BAP");
            commonComponents.CompleteOptionField("Incident Category", "Engine Overheating");
            bussinessProcessFlowPage.ClickBPFStage("Triage");
            bussinessProcessFlowPage.ClickNextStageButton();
            toolbar.WaitUntilRecordSaved();

            subgrid.NavigateToSubgridSection("Maintenance Tasks");
            subgrid.RefreshGridUntilRowsUpdated("Rows: 2");

            bussinessProcessFlowPage.ClickBPFStage("Repair");
            bussinessProcessFlowPage.EnterEstimateCompletionDate();
            bussinessProcessFlowPage.ClickNextStageButton();

            Assert.That(commonComponents.GetPopUpWindowTitle(), Is.EqualTo("Incomplete Maintenance Tasks"));
            Assert.That(commonComponents.GetPopUpWindowText(), Is.EqualTo("There are 2 pending maintenance tasks. Cannot move to Close stage."));
        }
    }
} 
