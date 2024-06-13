using Core;
using Core.Pages;
using Core.Pages.AvaTrade.Registration.FinancialDetails;
using Core.Pages.AvaTrade.Registration;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Tools;
using OpenQA.Selenium.Chrome;
using Core.Pages.AvaTrade.MainWebSite;
using Core.Pages.AvaTrade.TradingPlatform;
using Core.Pages.AvaTrade.TradingPlatform.PersonalData;

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
        protected readonly ATTermsAndConditionsPage termsAndConditionsPage = new ATTermsAndConditionsPage();
        protected readonly ATAlmostTherePage almostTherePage = new ATAlmostTherePage();
        protected readonly ATTradingPlatformPage mainPage = new ATTradingPlatformPage();
        #endregion

        public IWebDriver Driver;

        [SetUp]
        public void SetUp()
        {
            Driver = ChromeWebDriver.GetInstance();
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

            Driver.Dispose();
        }
    }
}
