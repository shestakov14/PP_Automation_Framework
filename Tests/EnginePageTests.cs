using Allure.NUnit;
using Allure.NUnit.Attributes;
using SPACE_Framework.Helpers;
using SPACE_Framework.Pages;
using SPACE_Framework.Views;
using static SPACE_Framework.TestData.TestData;

namespace SPACE_Framework.Tests
{
    [AllureNUnit]
    [AllureSuite("Engine Page")]
    public class EnginePageTests : BaseTest
    {
        EnginePage? enginePage;
        EnginesView? view;
        Toolbar? toolbar;
         
        [Test]
        public void Test_Create_EngineRecord()
        {
            enginePage = new EnginePage(driver);
            view = new EnginesView(driver);
            toolbar = new Toolbar(driver);

            enginePage.NavigateToEnginesTab();

            toolbar.ClickNewButton();

            enginePage.FillName(engineName);
            enginePage.SelectEngineModel("Hyperion 7");
            toolbar.ClickSaveAndClose();

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
