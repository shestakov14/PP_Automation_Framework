using OpenQA.Selenium;
using SPACE_Framework.Helpers;
using SPACE_Framework.QuickCreatePages;
using SPACE_Framework.Subgrids;
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

        public void CreteMaintenanceRecordFromToolbar(string outcomeIndex)
        {
            subgrid.NavigateToSubgridSection("Triage");
            commonComponents.CompleteOptionField("Assigned To", "BAP");
            commonComponents.CompleteOptionField("Incident Category", "Engine Overheating");
            bussinessProcessFlowPage.ClickBPFStage("Triage");
            bussinessProcessFlowPage.ClickNextStageButton();
            toolbar.WaitUntilRecordSaved();

            subgrid.NavigateToSubgridSection("Maintenance Tasks");
            subgrid.RefreshGridUntilRowsUpdated("Rows: 2");
            subgrid.SelectAllRecords();
            subgrid.ClickEditButton();
            commonComponents.CompleteDropdownField("Status", "3");
            Thread.Sleep(500);
            quickCreatePage.ClickSaveButton();
            subgrid.RefreshGridUntilRowsUpdated("Rows: 0");

            bussinessProcessFlowPage.ClickBPFStage("Repair");
            bussinessProcessFlowPage.EnterEstimateCompletionDate();
            bussinessProcessFlowPage.ClickNextStageButton();

            bussinessProcessFlowPage.ClickBPFStage("Close");
            bussinessProcessFlowPage.EnterActualCompletionDate();
            commonComponents.CompleteDropdownField("Final Outcome", outcomeIndex);
            bussinessProcessFlowPage.ClickFinishButton();
            toolbar.WaitUntilRecordSaved();
            toolbar.ClickSaveButton();
            subgrid.NavigateToSubgridSection("General");
        }

        public void CreteMaintenanceRecord(string name, string spacecraft, string assigne, string incidentCategory)
        {
            FillName(maintenanceName);
            SelectSpacecraft("Demo");
            toolbar.ClickSaveButton();

            subgrid.NavigateToSubgridSection("Triage");
            commonComponents.CompleteOptionField("Assigned To", "BAP");
            commonComponents.CompleteOptionField("Incident Category", "Engine Overheating");
            bussinessProcessFlowPage.ClickBPFStage("Triage");
            bussinessProcessFlowPage.ClickNextStageButton();
            toolbar.WaitUntilRecordSaved();

            subgrid.NavigateToSubgridSection("Maintenance Tasks");
            subgrid.RefreshGridUntilRowsUpdated("Rows: 2");
            subgrid.SelectAllRecords();
            subgrid.ClickEditButton();
            commonComponents.CompleteDropdownField("Status", "3");
            Thread.Sleep(500);
            quickCreatePage.ClickSaveButton();
            subgrid.RefreshGridUntilRowsUpdated("Rows: 0");

            bussinessProcessFlowPage.ClickBPFStage("Repair");
            bussinessProcessFlowPage.EnterEstimateCompletionDate();
            bussinessProcessFlowPage.ClickNextStageButton();

            toolbar.WaitUntilRecordSaved();
            bussinessProcessFlowPage.ClickBPFStage("Close");
            bussinessProcessFlowPage.EnterActualCompletionDate();
            commonComponents.CompleteDropdownField("Final Outcome", "2");
            bussinessProcessFlowPage.ClickFinishButton();
            toolbar.WaitUntilRecordSaved();
            toolbar.ClickSaveAndClose();
        }

    }
}
