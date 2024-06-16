using Core;
using Core.Pages.AvaTrade.Registration;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Core.Pages.AvaTrade.MainWebSite;
using Core.Pages.AvaTrade.TradingPlatform;
using Core.Pages.AvaTrade.TradingPlatform.FinancialDetails;
using Tools;
using Core.Pages.AvaTrade.TradingPlatform.Registration.PersonalData;
using Core.Pages.AvaTrade.TradingPlatform.Registration.FinancialDetails;
using Core.Pages.AvaTrade.TradingPlatform.Registration.Verification;
using Core.Pages.AvaTrade.TradingPlatform.Registration;

namespace Tests
{
    /// <summary>
    /// Base test class. Has all the common logic for AvaTrade testing
    /// </summary>
    public class BaseTest
    {
        #region Page definitions
        protected readonly HomePage avaTradeHomePage = new HomePage();
        protected readonly InitialSignUpPage initialSignUpPage = new InitialSignUpPage();
        protected readonly PersonalDetailsPage personalDetailsPage = new PersonalDetailsPage();
        protected readonly FinancialDetailsPage financialDetailsPage = new FinancialDetailsPage();
        protected readonly TradingExpiriencePage tradingExpiriencePage = new TradingExpiriencePage();
        protected readonly TermsAndConditionsPage termsAndConditionsPage = new TermsAndConditionsPage();
        protected readonly WarningPage warningPage = new WarningPage();
        protected readonly AlmostTherePage almostTherePage = new AlmostTherePage();
        protected readonly TradingPlatformPage mainPage = new TradingPlatformPage();
        protected readonly UploadDocumentsPage uploadDocumentsPage = new UploadDocumentsPage();
        protected readonly VerifyAccountPage verifyAccountPage = new VerifyAccountPage();
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

            Driver.SwitchTo().DefaultContent();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
