using OpenQA.Selenium;
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
        public static void ScrollIntoView(this IWebElement element, int? timeoutInSec = null)
        {
            ((IJavaScriptExecutor)ChromeWebDriver.GetInstance()).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public static void WaitForVisible(this IWebElement element, int? timeoutInSec = null)
        {
            var timeout = timeoutInSec != null ? timeoutInSec.Value : Config.DefaultTimeoutTimeInSec;
            try
            {
                var wait = new WebDriverWait(ChromeWebDriver.GetInstance(), TimeSpan.FromSeconds(timeout));
                wait.Until(driver => element.Displayed);
            }
            catch (Exception e)
            {
                throw new Exception($"Wait For Element {element} to become visible failed: {e.Message}");
            }
        }

        public static void WaitForDisappear(this IWebElement element, int? timeoutInSec = null)
        {
            var timeout = timeoutInSec != null ? timeoutInSec.Value : Config.DefaultTimeoutTimeInSec;
            try
            {
                var wait = new WebDriverWait(ChromeWebDriver.GetInstance(), TimeSpan.FromSeconds(timeout));
                wait.Until(ExpectedConditions.StalenessOf(element));
            }
            catch (Exception e)
            {
                throw new Exception($"Wait For Element {element} to disappear failed: {e.Message}");
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
