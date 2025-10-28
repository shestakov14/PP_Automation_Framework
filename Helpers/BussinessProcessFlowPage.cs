using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SPACE_Framework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPACE_Framework.Helpers
{
    public class BussinessProcessFlowPage : BasePage
    {
        CommonComponents CommonComps;
        public BussinessProcessFlowPage(IWebDriver driver) : base(driver)
        {
            CommonComps = new CommonComponents(driver);
        }

        public void ClickBPFStage(string stageName)
        {
            var locator = By.XPath($"//div[@title='{stageName}']//div[contains(@id, 'stageIndicatorHolder')]");
            var bpfStage = wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            bpfStage.Click();
        }

        public void ClickNextStageButton()
        {
            var locator = By.XPath($"//button[@aria-label=\"Next Stage\"]");
            ClickElementByLocator(locator);
        }

        public void ClickFinishButton()
        {
            var locator = By.XPath($"//button[@aria-label=\"Finish\"]");
            ClickElementByLocator(locator);
        }


        public void EnterEstimateCompletionDate() 
        {
            DateTime date = DateTime.Today;
            string formattedStartDate = date.ToString("MM-dd-yyyy");
            CommonComps.CompleteField("Date of Estimated Completion Date", formattedStartDate);
        }

        public void EnterActualCompletionDate()
        {
            DateTime date = DateTime.Today;
            string formattedStartDate = date.ToString("MM-dd-yyyy");
            CommonComps.CompleteField("Date of Actual Completion Date", formattedStartDate);
        }

    }
}
 