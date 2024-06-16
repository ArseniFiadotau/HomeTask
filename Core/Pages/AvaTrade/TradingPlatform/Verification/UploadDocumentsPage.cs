using Core.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Service.Options;
using OpenQA.Selenium.Support.UI;
using Tools;

namespace Core.Pages.AvaTrade.TradingPlatform.Verification
{
    /// <summary>
    /// Upload documents verification page
    /// </summary>
    public class UploadDocumentsPage : BasePage
    {
        protected By headerBy = By.XPath("//span[.='Upload Documents']");
        protected By customerIdentityVerificationBy = By.XPath("//button[contains(.,'Customer Identity Verification')]");
        protected By uploadFrontIDCardBy = By.XPath("//label[.='Front ID Card']");
        protected By otherDocumentsUploadBy= By.XPath("//button[contains(.,'Other Documents Upload')]");

        protected By avaTradeLogoBy = By.CssSelector("header a");

        public override void WaitForPageLoading()
        {
            base.WaitForPageLoading();
            WaitForVisible(headerBy, timeoutInSec: WaitTime.ThirtySec);
        }

        public bool IsDisplayed() => IsElementExist(headerBy, timeoutInSec: WaitTime.TenSec);

        public bool IsCustomerIdentityVerificationDisplayed() => IsElementExist(customerIdentityVerificationBy);
        public bool IsUploadFrontIDCardDisplayed() => IsElementExist(uploadFrontIDCardBy);
        public bool IsOtherDocumentsUploadDisplayed() => IsElementExist(otherDocumentsUploadBy);

        public void NavigateToMainPage()
        {
            Driver.SwitchTo().DefaultContent();

            var logo = Driver.FindElement(avaTradeLogoBy);
            logo.Click();
        }
    }
}
