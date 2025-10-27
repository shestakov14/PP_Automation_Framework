using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPACE_Framework.Views
{
    public class FleetsView : BaseView
    {
        public FleetsView(IWebDriver driver) : base(driver)
        {
        }

        public string GetRecordCategory(string index)
        {
            var locator = By.XPath($"(//div[@role='gridcell' and contains(@col-id, 'space_category')])[{index}]//label[@aria-label]");
            var recordCategory = FindElementByLocator(locator);

            return recordCategory.GetAttribute("aria-label");
        }
    }
}
 