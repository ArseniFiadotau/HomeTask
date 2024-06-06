using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using Tools;
using OpenQA.Selenium;
using System.Runtime.CompilerServices;

namespace Core
{
    public class AndroidDriver
    {
        private static ThreadLocal<AppiumDriver<AndroidElement>>? _driver;

        private AndroidDriver() { }

        public static AppiumDriver<AndroidElement> GetInstance()
        {
            if (_driver == null)
            {
                _driver = new ThreadLocal<AppiumDriver<AndroidElement>>
                {
                    Value = InitDriver()
                };
            }

            return _driver.Value;
        }
        
        private static AndroidDriver<AndroidElement> InitDriver()
        {
            var driverOptions = new AppiumOptions();

            driverOptions.AddAdditionalCapability("platformName", "Android");
            driverOptions.AddAdditionalCapability("appium:deviceName", "Pixel 7 API 34 Andr 14");
            driverOptions.AddAdditionalCapability("appium:automationName", "UiAutomator2");

            return new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/"), driverOptions);
        }

        public static void Quit()
        {
            if(_driver != null && _driver.Value != null)
            {
                _driver.Value.Quit();
                _driver = null;
            }
        }
    }
}
