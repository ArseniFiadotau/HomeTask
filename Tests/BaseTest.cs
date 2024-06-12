using Core;
using Core.Pages;
using Core.Pages.AvaTrade.Registration.FinancialDetails;
using Core.Pages.AvaTrade.Registration.PersonalData;
using Core.Pages.AvaTrade.Registration;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using Tools;

namespace Tests
{
    /// <summary>
    /// Base test class. Have all the common logic for AvaTrade testing
    /// </summary>
    public class BaseTest
    {
        #region Page definitions
        protected readonly AndroidHomePage androidHomePage = new AndroidHomePage();
        protected readonly ATGuestPage avaTradeGuestPage = new ATGuestPage();
        protected readonly ATInitialSignUpPage initialSignUpPage = new ATInitialSignUpPage();
        protected readonly ATBasicPersonalDetailsPage basicPersonalDetailsPage = new ATBasicPersonalDetailsPage();
        protected readonly ATAddressPersonalDetailsPage addressPersonalDetailsPage = new ATAddressPersonalDetailsPage();
        protected readonly ATFinancialDetailsFirstPage financialDetailsFirstPage = new ATFinancialDetailsFirstPage();
        protected readonly ATFinancialDetailsSecondPage financialDetailsSecondPage = new ATFinancialDetailsSecondPage();
        protected readonly ATTermsAndConditionsPage termsAndConditionsPage = new ATTermsAndConditionsPage();
        protected readonly ATAlmostTherePage almostTherePage = new ATAlmostTherePage();
        protected readonly ATMainPage mainPage = new ATMainPage();
        #endregion

        public AndroidDriver<AndroidElement> Driver;

        [SetUp]
        public void SetUp()
        {
            Driver = AndroidDriver.GetInstance();
            androidHomePage.OpenAvaTradeApp();
            avaTradeGuestPage.WaitForPageLoading();
        }

        [TearDown]
        public void TearDown()
        {
            // Makes screenshot in case of test failure
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshotPath = $"{DateTime.Now:yyyy-MM-dd HH-mm-ss}.png";
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            }

            Driver.TerminateApp(Config.AvaTradeAppId);
            Driver.Dispose();
        }
    }
}
