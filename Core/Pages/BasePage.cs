using OpenQA.Selenium;
using Core.Helpers;
using OpenQA.Selenium.Support.UI;
using Tools;
using System.Threading;

namespace Core.Pages
{
    /// <summary>
    /// Base page that is used by other pages to unify common logic
    /// </summary>
    public class BasePage
    {
        public static IWebDriver Driver = ChromeWebDriver.GetInstance();

        public virtual void WaitForPageLoading()
        {
            Console.WriteLine($"Loading page {this.GetType().Name}");
            WaitHelper.WaitForPageJsLoading();
        }
        
        protected void WaitForVisible(By element, int? timeoutInSec = null)
        {
            WaitHelper.WaitForVisible(element, timeoutInSec);
        }

        protected void WaitForDisappear(By element, int? timeoutInSec = null)
        {
            WaitHelper.WaitForDisappear(element, timeoutInSec);
        }

        protected bool IsElementExist(By element, int? timeoutInSec = null)
        {
            var timeout = timeoutInSec != null ? timeoutInSec.Value : Config.DefaultTimeoutTimeInSec;
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(element));

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        protected void SendKeysToElementBy(By elementBy, string text)
        {
            WaitForVisible(elementBy);
            try
            {
                Driver.FindElement(elementBy).SendKeys(text);
            }
            catch (Exception e)
            {
                throw new Exception($"\tFailed to send keys to the element: {elementBy}. {e.Message}");
            }
        }
    }
}
