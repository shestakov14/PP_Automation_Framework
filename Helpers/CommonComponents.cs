using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SPACE_Framework.Pages;

namespace SPACE_Framework.Helpers
{
    public class CommonComponents : BasePage
    {
        public CommonComponents(IWebDriver driver) : base(driver)
        {
                
        }

        public void CompleteField(string fieldLabel, string input)
        {
            TypeOnElementByLocator(By.XPath($"//input[@aria-label=\"{fieldLabel}\"]"),input);
        }

        public void DeleteRecord()
        {
            var deleteButtonRibonLocator = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@aria-label=\"Delete\"]")));
            deleteButtonRibonLocator.Click();
            var deleteConfirmationButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@data-id=\"confirmButton\"]")));
            deleteConfirmationButton.Click();    
        }

        public void CompleteOptionField(string fieldValue,string input)
        {
            var locator = By.XPath($"//input[@aria-label='{fieldValue}, Lookup']");
            ClickElementByLocator(locator);

            TypeOnElementByLocator(locator, input);

            LookUpWait(fieldValue.ToLower().Replace(" ",""));

            FindElementByLocator(locator).SendKeys(Keys.Enter);
        }

        public void UpdateOptionFieldValue(string field, string input)
        {
            var clearLocator = By.XPath($"//button[contains(@aria-label, 'Delete') and contains(@data-id, '{field.ToLower().Replace(" ", "")}')]");
            ClickElementByLocator(clearLocator);

            var locatorSearch = By.XPath($"//input[@aria-label='{field}, Lookup']");
            ClickElementByLocator(locatorSearch);

            TypeOnElementByLocator(locatorSearch, input);

            LookUpWait(field.ToLower().Replace(" ", ""));

            FindElementByLocator(locatorSearch).SendKeys(Keys.Enter);
        }

        public void CompleteDropdownField(string fieldLabel, string index)
        {
            var dropdownFieldLocator = By.XPath($"//button[@aria-label=\"{fieldLabel}\"]");
            ClickElementByLocator(dropdownFieldLocator);

            var dropdownOptionLocator = By.XPath($"(//div[@role=\"listbox\"]//div[contains(@id, 'option')])[{index}]");
            ClickElementByLocator(dropdownOptionLocator);
        }

        public void NavigateToTab(string tab)
        {
            var tabLocator = By.XPath($"//span[contains(@class, 'pa-') and contains(text(), '{tab}')]");
            ClickElementByLocator(tabLocator);
        }

        public string GetRecordTitle()
        {
            var header = FindElementByLocator(By.XPath("//h1[@data-id=\"header_title\"]"));
            string headerFullText = header.Text;
            var span = header.FindElement(By.TagName("span"));
            string spanText = span.Text;
            string recordTitle = headerFullText.Replace(spanText, "").Trim();

            return recordTitle;
        }

    }
}
