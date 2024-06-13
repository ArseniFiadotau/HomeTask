using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Tools;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Core.Components
{
    public class ProgressBar
    {
        public static IWebDriver Driver = ChromeWebDriver.GetInstance();


        private static By progressBarBy = By.CssSelector("div[class='v-overlay__content'] div[role='progressbar']");

        public static void WaitForVisible(int? timeoutInSec = null)
        {
            var timeout = timeoutInSec != null ? timeoutInSec.Value : Config.DefaultTimeoutTimeInSec;
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementIsVisible(progressBarBy));
            }
            catch (Exception ex)
            {
                var a = ex;
                throw;
            }
        }

        public static void WaitForDisappear(int? timeoutInSec = null)
        {
            var timeout = timeoutInSec != null ? timeoutInSec.Value : Config.DefaultTimeoutTimeInSec;
            try
            {
                var progressBar = Driver.FindElement(progressBarBy); 
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.StalenessOf(progressBar));
            }
            catch (Exception ex)
            {
                var a = ex;
                throw;
            }
        }
    }
}
