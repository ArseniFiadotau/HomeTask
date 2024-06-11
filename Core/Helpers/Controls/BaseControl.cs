using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace Core.Helpers.Controls
{
    public class BaseControl
    {
        public static AndroidDriver<AndroidElement> Driver = AndroidDriver.GetInstance();
        public By BaseControlBy;

        public BaseControl(By baseControlBy)
        {
            BaseControlBy = baseControlBy;
        }

        public AndroidElement Find()
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
