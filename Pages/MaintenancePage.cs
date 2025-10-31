using OpenQA.Selenium;
using SPACE_Framework.Helpers;
using SPACE_Framework.QuickCreatePages;
using SPACE_Framework.Views;
using static SPACE_Framework.TestData.TestData;

namespace SPACE_Framework.Pages
{
    public class MaintenancePage : BasePage
    {
        CommonComponents commonComponents;
        BussinessProcessFlowPage bussinessProcessFlowPage;
        Toolbar toolbar;
        BaseSubgrid subgrid;
        BaseQuickCreatePage quickCreatePage;
        
        public MaintenancePage(IWebDriver driver) : base(driver)
        {
            commonComponents = new CommonComponents(driver);
            bussinessProcessFlowPage = new BussinessProcessFlowPage(driver);
            toolbar = new Toolbar(driver);
            subgrid = new BaseSubgrid(driver);
            quickCreatePage = new BaseQuickCreatePage(driver);
        }

        public void FillName(string name)
        {
            commonComponents.CompleteField("Name", name);
        }

        public void SelectSpacecraft(string spacecraftName)
        {
            commonComponents.CompleteOptionField("Spacecraft", spacecraftName);
        }

        public void CreteMaintenanceRecordFromToolbar()
        {
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
        }

        public void CreteMaintenanceRecord(string name, string spacecrat, string assigne, string incidentCategory)
        {
            FillName(maintenanceName);
            SelectSpacecraft("Demo");
            toolbar.ClickSaveButton();

            bussinessProcessFlowPage.ClickBPFStage("Triage");
            commonComponents.CompleteOptionField("Assigned To", "BAP");
            commonComponents.CompleteOptionField("Incident Category", "Engine Overheating");
            Thread.Sleep(5000);
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
        }

    }
}
