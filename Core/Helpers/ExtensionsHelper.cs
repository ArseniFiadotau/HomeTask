using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using Tools;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Core.Helpers
{
    public static class ExtensionsHelper
    {
        public static void WaitForVisible(this AndroidElement element, int? timeoutInSec = null)
        {
            var timeout = timeoutInSec != null ? timeoutInSec.Value : Config.DefaultTimeoutTimeInSec;
            try
            {
                var wait = new WebDriverWait(AndroidDriver.GetInstance(), TimeSpan.FromSeconds(timeout));
                wait.Until(driver => element.Displayed);
            }
            catch (Exception e)
            {
                throw new Exception($"Wait For Element {element} to become visible failed: {e.Message}");
            }
        }

        public static void WaitForDisappear(this AndroidElement element, int? timeoutInSec = null)
        {
            var timeout = timeoutInSec != null ? timeoutInSec.Value : Config.DefaultTimeoutTimeInSec;
            try
            {
                var wait = new WebDriverWait(AndroidDriver.GetInstance(), TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (Exception e)
            {
                throw new Exception($"Wait For Element {element} to disappear failed: {e.Message}");
            }
        }


    }
}
