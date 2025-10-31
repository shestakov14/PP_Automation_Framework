using Allure.NUnit;
using Allure.NUnit.Attributes;
using SPACE_Framework.Helpers;
using SPACE_Framework.Pages;
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
            maintenancePage.FillName(maintenanceName);
            maintenancePage.SelectSpacecraft("Demo");
            toolbar.ClickSaveButton();

            bussinessProcessFlowPage.ClickBPFStage("Triage");
            commonComponents.CompleteOptionField("Assigned To", "BAP");
            commonComponents.CompleteOptionField("Incident Category", "Engine Overheating");
            bussinessProcessFlowPage.ClickNextStageButton();
            toolbar.WaitUntilRecordSaved();

            subgrid.NavigateToSubgridSection("Maintenance Tasks");
            subgrid.RefreshGridUntilRowsUpdated("Rows: 2");
            subgrid.SelectAllRecords();
            subgrid.ClickEditButton();
            commonComponents.CompleteDropdownField("Status", "3");
            Thread.Sleep(1000);
            quickCreatePage.ClickSaveButton();
            subgrid.RefreshGridUntilRowsUpdated("Rows: 0");

            bussinessProcessFlowPage.ClickBPFStage("Repair");
            bussinessProcessFlowPage.EnterEstimateCompletionDate();
            bussinessProcessFlowPage.ClickNextStageButton();

            bussinessProcessFlowPage.ClickBPFStage("Close");
            bussinessProcessFlowPage.EnterActualCompletionDate();
            commonComponents.CompleteDropdownField("Final Outcome", "2");
            bussinessProcessFlowPage.ClickFinishButton();
            toolbar.WaitUntilRecordSaved();
            toolbar.ClickSaveAndClose();

            view.OpenInactiveRecordsView();
            toolbar.ClickRefreshButton();
            toolbar.ClickRefreshButton();

            string recordName = view.GetRecordName("1");
            string recordComletionDate = view.GetRecordCompletionDate("1");
            string recordAssigne = view.GetRecordAssignedTo("1");
            string recordDiagnostic = view.GetRecordDiagnostic("1");
            string recordRepair = view.GetRecordRepair("1");
            string recordSeverity = view.GetRecordSeverity("1");
            string completionDate = DateTime.Today.ToString("MM/dd/yyyy");

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
    }
} 
