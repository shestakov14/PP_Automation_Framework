using OpenQA.Selenium;
using SPACE_Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPACE_Framework.Pages
{
    public class EnginePage : BasePage
    {
        CommonComponents commonComps;
        public EnginePage(IWebDriver driver) : base(driver)
        {
            commonComps = new CommonComponents(driver);
        }

        public void FillName(string engineName)
        {
            commonComps.CompleteField("Name", engineName);
        }

        public void SelectEngineModel(string engineModel)
        {
            commonComps.CompleteOptionField("Engine Model", engineModel);
        }
        public void NavigateToEnginesTab()
        {
            commonComps.NavigateToTab("Fleet Department");
            commonComps.NavigateToTab("Engine Department");
            commonComps.NavigateToTab("Engines");
        }
    }
} 
