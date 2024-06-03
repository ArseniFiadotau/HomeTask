using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using Tools;

namespace Core.Helpers
{
    internal class WaitHelper
    {
        public static void WaitForElementTextChange(AndroidElement element, string text, int? timeoutInSec = null)
        {
            var timeout = timeoutInSec != null ? timeoutInSec.Value : Config.DefaultTimeoutTimeInSec;
            try
            {
                var wait = new WebDriverWait(AndroidDriver.GetInstance(), TimeSpan.FromSeconds(timeout));
                wait.Until(driver => element.Text.Equals(text));
            }
            catch (Exception e)
            {
                throw new Exception($"Wait For Element {element} text to change failed: {e.Message}");
            }
        }
    }
}
