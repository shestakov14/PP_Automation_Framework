using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace SPACE_Framework.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        protected IWebElement FindElementByLocator(By by)
        {
            // return wait.Until(driver => driver.FindElement(by));
            return wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        protected IList<IWebElement> FindElementsByLocator(By by)
        {
           return wait.Until(driver => driver.FindElements(by));

        }

        protected void  ClickElementByLocator(By by, int retries = 5)
        {
            int attempt = 0;

            while (attempt < retries)
            {
                try
                {
                    FindElementByLocator(by).Click();
                    return;
                }
                catch (StaleElementReferenceException)
                {
                }
                catch (NoSuchElementException)
                {
                }
                catch (Exception ex)
                {

                    throw new Exception("Clicking Failed", ex);
                }

                Thread.Sleep(500);
                attempt++;
            }

            throw new Exception($"Failed to click element after {retries} attempts.");


           // FindElementByLocator((By)by).Click();
        }

        protected void TypeOnElementByLocator(By by, string text)
        {
            var field = FindElementByLocator((By)by);
            field.SendKeys(Keys.Control + "a");
            field.SendKeys(Keys.Backspace);
            field.SendKeys(text);
        }

        protected void ClearElementTextByLocator(By by)
        {
            var field = FindElementByLocator((By)by);
            field.SendKeys(Keys.Control + "a");
            field.SendKeys(Keys.Delete);
        }

        protected string GetTextFromElementByLocator(By by)
        {
            var element = FindElementByLocator((By)by);
            string result = element.Text;
            return result;
        }

        protected bool IsElementVisible(By by)
        {
            try
            {
                var elemenet = driver.FindElement(by);
                return elemenet.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (TimeoutException)
            {
                return false;
            }
        }

         
        protected IList<IWebElement> LookUpWait(string lookupLabel)
        {
            List<IWebElement> elements;

            try
            {
                elements = wait.Until(driver =>
                {
                    var foundElements = driver.FindElements(By.XPath($"//li[contains(@data-id, '{lookupLabel}')]"));

                    return foundElements.All(e => e.Displayed) && foundElements.Count > 0 ? foundElements : null;

                }).ToList();
            }

            catch (WebDriverTimeoutException)
            {
                elements = new List<IWebElement>();
            }
            return elements;
        }
    }
}
