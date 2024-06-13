using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Tools;

namespace Core
{
    public class ChromeWebDriver
    {
        private static IWebDriver _driver;
        private static object syncRoot = new Object();
        
        private ChromeWebDriver() { }

        public static IWebDriver GetInstance()
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

        private static ChromeDriver InitDriver()
        {
            var driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Config.AvaTradeWebSite);

            return driver;
        }
    }
}
