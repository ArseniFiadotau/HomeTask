using Core;
using Core.Pages;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System.Diagnostics.CodeAnalysis;
using Tools;

namespace Tests
{
    [SuppressMessage("Structure", "NUnit1032:An IDisposable field/property should be Disposed in a TearDown method", Justification = "Disposing happens in Driver.Close() method")]
    public class BaseTest
    {
        public readonly AndroidHomePage androidHomePage = new AndroidHomePage();
        public readonly ATGuestPage avaTradeGuestPage = new ATGuestPage();

        public readonly AppiumDriver<AndroidElement> Driver = AndroidDriver.GetInstance();

        [SetUp]
        public void SetUp()
        {
            androidHomePage.OpenAvaTradeApp();
            avaTradeGuestPage.WaitForPageLoading();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshotPath = $"{DateTime.Now:yyyy-MM-dd HH-mm-ss}.png";
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            }

            Driver.TerminateApp(Config.AvaTradeAppId);
            Driver.Close();
        }
    }
}
