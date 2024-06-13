using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace Core.Helpers.Controls
{
    /// <summary>
    /// Base custom control class. Used to determine common behavior for other controls.
    /// Also quite useful to extend control functionality, add logs, increase timeout etc.
    /// </summary>
    public class BaseControl
    {
        public IWebDriver Driver = ChromeWebDriver.GetInstance();
        public By BaseControlBy;

        public BaseControl(By baseControlBy)
        {
            BaseControlBy = baseControlBy;
        }

        public IWebElement Find()
        {
            return Driver.FindElement(BaseControlBy);
        }

        public virtual void WaitForVisible(int? timeoutInSec = null)
        {

        }

        public void Click()
        {
            Find().Click();
        }
    }
}
