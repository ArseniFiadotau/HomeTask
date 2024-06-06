using OpenQA.Selenium.Appium.Android;

namespace Core.Helpers.Controls
{
    public class BaseControl
    {
        public static AndroidDriver<AndroidElement> Driver = AndroidDriver.GetInstance();

        public virtual void WaitForVisible()
        {

        }
    }
}
