using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using Core.Helpers;

namespace Core.Pages
{
    public class BasePage
    {
        public static AppiumDriver<AndroidElement> Driver = AndroidDriver.GetInstance();

        public virtual void WaitForPageLoading()
        {

        }

        public void WaitForVisible(By element, int? timeoutInSec = null)
        {
            WaitHelper.WaitForVisible(element, timeoutInSec);
        }

        public void WaitForDisappear(By element, int? timeoutInSec = null)
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
