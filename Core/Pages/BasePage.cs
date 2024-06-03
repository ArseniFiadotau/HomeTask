using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Appium.Android;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Core.Pages
{
    public class BasePage
    {
        public static AppiumDriver<AndroidElement> Driver = AndroidDriver.GetInstance();

        public virtual void WaitForPageLoading()
        {

        }

        protected void ClickElementBy(By element)
        {
            WaitForVisible(element);
            try
            {
                Driver.FindElement(element).Click();
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to click on the element: {element}. {e.Message}");
            }
        }

        protected void SendKeysToElementBy(By element, string text)
        {
            WaitForVisible(element);
            try
            {
                Driver.FindElement(element).SendKeys(text);
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to send keys to the element: {element}. {e.Message}");
            }
        }

        protected bool IsElementByAppear(By element)
        {
            try
            {
                Driver.FindElement(element);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected void WaitForVisible(By element, int? timeoutInSec = null)
        {
            var timeout = timeoutInSec != null ? timeoutInSec.Value : Tools.Config.DefaultTimeoutTimeInSec;
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

        protected void WaitForDisappear(By element, int? timeoutInSec = null)
        {
            var timeout = timeoutInSec != null ? timeoutInSec.Value : Tools.Config.DefaultTimeoutTimeInSec;
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
