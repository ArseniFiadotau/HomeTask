using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using Core.Helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Tools;

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
            WaitForPageToLoad();
        }

        private void WaitForPageToLoad()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(WaitTime.ThirtySec));
            try
            {
                wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            }
            catch (Exception ex)
            {
                throw new TimeoutException("Timeout during page load", ex);
            }
        }

        protected void WaitForVisible(By element, int? timeoutInSec = null)
        {
            WaitHelper.WaitForVisible(element, timeoutInSec);
        }

        protected void WaitForDisappear(By element, int? timeoutInSec = null)
        {
            WaitHelper.WaitForDisappear(element, timeoutInSec);
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
                throw new Exception($"Failed to send keys to the element: {elementBy}. {e.Message}");
            }
        }
    }
}
