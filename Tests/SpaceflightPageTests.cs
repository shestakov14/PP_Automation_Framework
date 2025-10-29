using Allure.NUnit;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using SPACE_Framework.Helpers;
using SPACE_Framework.Pages;
using SPACE_Framework.Views;
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

        [Test]
        public void Test_Create_Spaceflight()
        {
            commonComponents = new CommonComponents(driver);
            spaceflightPage = new SpaceflightPage(driver);

            commonComponents.NavigateToTab("Spaceflights");

            commonComponents.ClickNewButtonFromToolbar();
            spaceflightPage.FillName(spaceflightName);
            spaceflightPage.SelectSpacecraft("Cspacecraft-ES17");
            spaceflightPage.SelectLandingSpaceport(spaceportNY);
            spaceflightPage.SelectLaunchSpaceport(spaceportSF);
            spaceflightPage.SetStartEndDate();
            commonComponents.ClickSaveButtonFromToolbar();
        }

         
        [Test]
        public void Test_Update_Spaceflight()
        {
            commonComponents = new CommonComponents(driver);
            spaceflightPage = new SpaceflightPage(driver);
            view = new SpaceflightView(driver);

            commonComponents.NavigateToTab("Spaceflights");
            view.OpenActiveRecordByIndex("1");
            spaceflightPage.UpdateSpaceFlight("updatedFlight", spaceportNY, spaceportSF);
            commonComponents.ClickSaveButtonFromToolbar();
        }

        [Test]
        public void Test_Delete_Spaceflight()
        {
            commonComponents = new CommonComponents(driver);
            spaceflightPage = new SpaceflightPage(driver);
            view = new SpaceflightView(driver);

            commonComponents.NavigateToTab("Spaceflights");
            view.OpenActiveRecordByIndex("1");
            var spaceflightName = spaceflightPage.GetRecordName();
            commonComponents.DeleteRecord();

            var viewTitle = view.GetTabView("Active Spaceflights");
            Assert.That(viewTitle, Is.EqualTo("Active Spaceflights"));

            Assert.That(view.CheckRecordPresent(spaceflightName), Is.False, "Element should not be present on the page.");
        }

        [Test]
        public void Test()
        {
            commonComponents = new CommonComponents(driver);
            spaceflightPage = new SpaceflightPage(driver);
            view = new SpaceflightView(driver);

            Assert.That(view.GetRecordName("2"), Is.EqualTo("AU-888"));
           
        }
    }
}
