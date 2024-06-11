using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;

namespace Core
{
    public class AndroidDriver
    {
        private static AndroidDriver<AndroidElement>? _driver;
        private static object syncRoot = new Object();
        
        private AndroidDriver() { }

        public static AndroidDriver<AndroidElement> GetInstance()
        {
            if (_driver == null)
            {
                lock (syncRoot)
                {
                    if (_driver == null)
                    {
                        _driver = InitDriver();
                    }
                }
            }

            return _driver;
        }

        private static AndroidDriver<AndroidElement> InitDriver()
        {
            var driverOptions = new AppiumOptions();

            driverOptions.AddAdditionalCapability("platformName", "Android");
            driverOptions.AddAdditionalCapability("appium:platformVersion", "12.0");
            driverOptions.AddAdditionalCapability("appium:automationName", "UiAutomator2");

            return new AndroidDriver<AndroidElement>(new Uri("http://192.168.100.126:5555"), driverOptions);
        }
    }
}
