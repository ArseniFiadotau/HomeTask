using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using Tools;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Core.Helpers
{
    public static class WaitHelper
    {
        private static readonly AppiumDriver<AndroidElement> Driver = AndroidDriver.GetInstance();

        public static void WaitForElementTextChange(By element, string text, int? timeoutInSec = null)
        {
            var timeout = timeoutInSec != null ? timeoutInSec.Value : Config.DefaultTimeoutTimeInSec;
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                wait.Until(driver => Driver.FindElement(element).Text.Equals(text));
            }
            catch (Exception e)
            {
                throw new Exception($"Wait For Element {element} text to change failed: {e.Message}");
            }
        }

        public static void WaitForVisible(By element, int? timeoutInSec = null)
        {
            var timeout = timeoutInSec != null ? timeoutInSec.Value : Config.DefaultTimeoutTimeInSec;
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.ElementIsVisible(element));
            }
            catch (Exception e)
            {
                throw new Exception($"Wait For Element {element} to become visible failed: {e.Message}");
            }
        }

        public static void WaitForDisappear(By element, int? timeoutInSec = null)
        {
            var timeout = timeoutInSec != null ? timeoutInSec.Value : Config.DefaultTimeoutTimeInSec;
            try
            {
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(element));
            }
            catch (Exception e)
            {
                throw new Exception($"Wait For Element {element} to disappear failed: {e.Message}");
            }
        }
    }
}
