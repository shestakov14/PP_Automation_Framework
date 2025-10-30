using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SPACE_Framework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPACE_Framework.Views
{
    public class BaseView : BasePage
    {
        public BaseView(IWebDriver driver) : base(driver)
        {
        }

        public string GetRecordName(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_name')])[{index}]//a[@href]");
            var recordName = FindElementByLocator(locator);

            return recordName.GetAttribute("aria-label");
        }

        public string GetRecordCreationDate(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'createdon')])[{index}]//label[@aria-label]");
            var recordDate = FindElementByLocator(locator);

            return recordDate.GetAttribute("aria-label");
        }

        public void OpenActiveRecordByName(string recordName)
        {
            var recordLocator = By.XPath($"//div//a[@aria-label=\"{recordName}\"]");
            ClickElementByLocator(recordLocator);
        }

        public void OpenActiveRecordByIndex(string index)
        {
            var recordLocator = By.XPath($"(//div[@role='row'][{index}]//a[contains(@aria-label, '')])[1]");
            ClickElementByLocator(recordLocator);
        }

        public string GetTabView(string tabName)
        {
            var tabViewLocator = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//button[contains(@title, '{tabName}')]//span[contains(text(), '{tabName}')]")));
      
            return tabViewLocator.Text;
        }

    }
}
