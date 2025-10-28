using OpenQA.Selenium;
using SPACE_Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPACE_Framework.Pages
{
    public class MaintenancePage : BasePage
    {
        CommonComponents CommonComps;
        
        public MaintenancePage(IWebDriver driver) : base(driver)
        {
            CommonComps = new CommonComponents(driver);
        }

        public void FillName(string name)
        {
            CommonComps.CompleteField("Name", name);
        }
        public void SelectSpacecraft(string spacecraftName)
        {
            CommonComps.CompleteOptionField("Spacecraft", spacecraftName);
        }

    }
}
