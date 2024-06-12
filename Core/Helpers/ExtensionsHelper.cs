using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using Tools;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Core.Helpers
{
    /// <summary>
    /// Class that contain different method extensions. Allow to use additional functions without creating specific helpers.
    /// May be worth to split it to several classes.
    /// </summary>
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

        public static void HideKeyboardIfShown(this AndroidDriver<AndroidElement> driver)
        {
            // added wait in case of small instabilities. Not a good solution, but works for now
            Thread.Sleep(TimeSpan.FromSeconds(WaitTime.ThreeSec));

            if (driver.IsKeyboardShown())
            {
                driver.PressKeyCode(new KeyEvent(AndroidKeyCode.Back));
                var func = () => !driver.IsKeyboardShown();
                WaitHelper.WaitUntilTrue(func);
            }
        }

        public static string GetStringValue(this Enum value)
        {
            var enumType = value.GetType();
            var name = Enum.GetName(enumType, value);
            
            var attr = enumType.GetField(name).GetCustomAttributes(false).OfType<StringValueAttribute>().SingleOrDefault();

            if (attr == null)
                throw new CustomAttributeFormatException("No custom attribute 'StringValue' is set for enum value " + value.ToString());

            return attr.Text;    
        }
    }
}
