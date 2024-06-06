using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;

namespace Core
{
    public class AndroidDriver
    {
        private static AppiumDriver<AndroidElement>? _driver;
        private static object syncRoot = new Object();
        
        private AndroidDriver() { }

        public static AppiumDriver<AndroidElement> GetInstance()
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
            driverOptions.AddAdditionalCapability("appium:deviceName", "Pixel 7 API 34 Andr 14");
            driverOptions.AddAdditionalCapability("appium:automationName", "UiAutomator2");

            return new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723"), driverOptions);
        }
    }
}
