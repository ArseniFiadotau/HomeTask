using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Core
{
    /// <summary>
    /// Chrome driver singleton class
    /// </summary>
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

            return driver;
        }
    }
}
