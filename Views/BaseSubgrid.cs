using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SPACE_Framework.Views
{
    public class BaseSubgrid : BaseView
    {
        public BaseSubgrid(IWebDriver driver) : base(driver)
        {
        }

        public string GetSubgridRowsCount()
        {
            var locator = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath
              ("//div//span[contains(@class, \"statusTextContainer\")]")));
            return locator.Text;
        } 

        public void ClickRefreshButton()
        {
            var refreshButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath
               ("//div[contains(@data-id, 'dataSetRoot')]//button[@aria-label=\"Refresh\"]")));
            refreshButton.Click();
        }

        public void SelectAllRecords()
        {
            var selectAllButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath
                ("(//div[contains(@class,\"ms-Checkbox\")])[1]")));
            selectAllButton.Click();
        }

        public void ClickEditButton()
        {
            var locator = By.XPath("//button[@aria-label=\"Edit\"]");
            ClickElementByLocator(locator);
        }

        public void RefreshGridUntilRowsUpdated(string desiredValue) 
        {
            string initialRowsValue = GetSubgridRowsCount();

            while (initialRowsValue != desiredValue)
            {
                ClickRefreshButton();
                initialRowsValue = GetSubgridRowsCount();
            }
        }

        public void NavigateToSubgridSection(string section)
        {
            var sectionLocator = By.XPath($"//li[contains(@id, 'tab') and contains(@aria-label, '{section}')]");
            ClickElementByLocator(sectionLocator);
        }

        public void ClickNewButton(string recordType) 
        {
            var buttonLocator = By.XPath($"//button[@aria-label=\"New {recordType}. Add New {recordType}\"]");
            ClickElementByLocator(buttonLocator);
        }
    }
}
