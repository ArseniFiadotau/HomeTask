using Core;
using Core.Pages.AvaTrade.Registration;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Core.Pages.AvaTrade.MainWebSite;
using Core.Pages.AvaTrade.TradingPlatform;
using Core.Pages.AvaTrade.TradingPlatform.PersonalData;
using Core.Pages.AvaTrade.TradingPlatform.FinancialDetails;
using Tools;

namespace Tests
{
    /// <summary>
    /// Base test class. Have all the common logic for AvaTrade testing
    /// </summary>
    public class BaseTest
    {
        #region Page definitions
        protected readonly ATHomePage avaTradeHomePage = new ATHomePage();
        protected readonly ATInitialSignUpPage initialSignUpPage = new ATInitialSignUpPage();
        protected readonly ATPersonalDetailsPage personalDetailsPage = new ATPersonalDetailsPage();
        protected readonly ATFinancialDetailsPage financialDetailsPage = new ATFinancialDetailsPage();
        protected readonly ATTradingExpiriencePage tradingExpiriencePage = new ATTradingExpiriencePage();
        protected readonly ATTermsAndConditionsPage termsAndConditionsPage = new ATTermsAndConditionsPage();
        protected readonly ATAlmostTherePage almostTherePage = new ATAlmostTherePage();
        protected readonly ATTradingPlatformPage mainPage = new ATTradingPlatformPage();
        #endregion

        public IWebDriver Driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Driver = ChromeWebDriver.GetInstance();
        }

        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().GoToUrl(Config.AvaTradeWebSite);
            avaTradeHomePage.WaitForPageLoading();
            avaTradeHomePage.AcceptCookies();
        }

        [TearDown]
        public void TearDown()
        {
            // Makes screenshot in case of test failure
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshotPath = $"{DateTime.Now:yyyy-MM-dd HH-mm-ss}.png";
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile(screenshotPath);
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
