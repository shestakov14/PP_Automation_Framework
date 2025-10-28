using Allure.NUnit;
using Allure.NUnit.Attributes;
using SPACE_Framework.Helpers;
using SPACE_Framework.Pages;
using SPACE_Framework.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPACE_Framework.Tests
{
    [AllureNUnit]
    [AllureSuite("Maintenance Page")]
    public class MaintenancePageTests : BaseTest
    {
        CommonComponents? commonComponents;
        MaintenancePage? maintenancePage;
        BussinessProcessFlowPage? bussinessProcessFlowPage;
        BaseView? view;
        BaseSubgrid? subgrid;

        [Test]
        public void Test_CreateMaintenanceRecord()
        {
            commonComponents = new CommonComponents(driver);
            maintenancePage = new MaintenancePage(driver);
            bussinessProcessFlowPage = new BussinessProcessFlowPage(driver);
            view = new BaseView(driver);
            subgrid = new BaseSubgrid(driver);

            commonComponents.NavigateToTab("Maintenances");
            commonComponents.ClickNewButtonFromToolbar();
            maintenancePage.FillName("record101abc");
            maintenancePage.SelectSpacecraft("Demo");
            commonComponents.ClickSaveButtonFromToolbar();

            bussinessProcessFlowPage.ClickBPFStage("Triage");
            commonComponents.CompleteOptionField("Assigned To", "BAP");
            commonComponents.CompleteOptionField("Incident Category", "Engine Overheating");
            bussinessProcessFlowPage.ClickNextStageButton();
            commonComponents.WaitUntilRecordSaved();
            commonComponents.NavigateToSubgridSection("Maintenance Tasks");

            subgrid.RefreshGridUntilRowsUpdated("Rows: 2");

            subgrid.SelectAllRecords();
            subgrid.ClickEditButton();

            commonComponents.CompleteDropdownField("Status", "3");
            Thread.Sleep(1000);
            commonComponents.ClickSaveButtonQuickCreate();

            subgrid.RefreshGridUntilRowsUpdated("Rows: 0");

            bussinessProcessFlowPage.ClickBPFStage("Repair");
            bussinessProcessFlowPage.EnterEstimateCompletionDate();
            bussinessProcessFlowPage.ClickNextStageButton();

            bussinessProcessFlowPage.ClickBPFStage("Close");
            bussinessProcessFlowPage.EnterActualCompletionDate();
            commonComponents.CompleteDropdownField("Final Outcome", "2");
            bussinessProcessFlowPage.ClickFinishButton();
            commonComponents.WaitUntilRecordSaved();


        }
    }
} 
