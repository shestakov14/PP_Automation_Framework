using OpenQA.Selenium;
using SPACE_Framework.Helpers;

namespace SPACE_Framework.Pages
{
    public class EnginePage : BasePage
    {
        CommonComponents commonComponents;
        public EnginePage(IWebDriver driver) : base(driver)
        {
            commonComponents = new CommonComponents(driver);
        }

        public void FillName(string engineName)
        {
            commonComponents.CompleteField("Name", engineName);
        }

        public void SelectEngineModel(string engineModel)
        {
            commonComponents.CompleteOptionField("Engine Model", engineModel);
        }

        public void NavigateToEnginesTab()
        {
            commonComponents.NavigateToTab("Fleet Department");
            commonComponents.NavigateToTab("Engine Department");
            commonComponents.NavigateToTab("Engines");
        }
    }
} 
