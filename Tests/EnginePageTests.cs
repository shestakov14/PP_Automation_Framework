using Allure.NUnit;
using Allure.NUnit.Attributes;
using SPACE_Framework.Helpers;
using SPACE_Framework.Pages;
using SPACE_Framework.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static SPACE_Framework.TestData.TestData;

namespace SPACE_Framework.Tests
{
    [AllureNUnit]
    [AllureSuite("Engine Page")]
    public class EnginePageTests : BaseTest
    {
        CommonComponents? commonComponents;
        EnginePage? enginePage;
        EnginesView? view;
         
        [Test]
        public void Test_Create_EngineRecord()
        {
            commonComponents = new CommonComponents(driver);
            enginePage = new EnginePage(driver);
            view = new EnginesView(driver);

            enginePage.NavigateToEnginesTab();

            commonComponents.ClickNewButtonFromToolbar();

            enginePage.FillName(engineName);
            enginePage.SelectEngineModel("Hyperion 7");
            commonComponents.ClickSaveAndCloseButtonFromToolbar();

            string enginesView = view.GetTabView("Engines");
            string recordName = view.GetRecordName("1");
            string recordLease = view.GetEngineLeaseValue("1");
            string recordModel = view.GetRecordModel("1");
            string recordStatus = view.GetRecordStatus("1");

            Assert.That(enginesView, Is.EqualTo("Active Engines"));
            Assert.That(recordName, Is.EqualTo(engineName));
            Assert.That(recordLease, Is.EqualTo("No"));
            Assert.That(recordModel, Is.EqualTo("Hyperion 7"));
            Assert.That(recordStatus, Is.EqualTo("100"));

        }
    }
}
