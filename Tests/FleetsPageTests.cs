using Allure.NUnit;
using Allure.NUnit.Attributes;
using SPACE_Framework.Helpers;
using SPACE_Framework.Pages;
using SPACE_Framework.Views;

namespace SPACE_Framework.Tests
{
    [AllureNUnit]
    [AllureSuite("Fleets Page")]

    public class FleetsPageTests : BaseTest
    {
        CommonComponents? commonComponents;
        FleetsView? view;

        [Test]
        public void Test_NavigateTo_Fleets_Section()
        {
            commonComponents = new CommonComponents(driver);
            view = new FleetsView(driver);

            commonComponents.NavigateToTab("Fleets");
            Assert.That(view.GetTabView("Fleets"), Is.EqualTo("Active Fleets"));
        }
    }
}
