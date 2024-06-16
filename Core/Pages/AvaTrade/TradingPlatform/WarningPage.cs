using Core.Helpers;
using Core.Helpers.Controls;
using Core.Pages.AvaTrade.TradingPlatform.Verification;
using OpenQA.Selenium;
using Tools;

namespace Core.Pages.AvaTrade.TradingPlatform
{
    /// <summary>
    /// 'WarningPage' page that appear when user enters not valid options for optimal trading 
    /// </summary>
    public class WarningPage : BasePage
    {
        protected By headerBy => By.XPath("//span[.='Warning']");
        protected By iAgreeButtonBy => By.XPath("//label[.//span[.='I agree']]");
        protected By completeRegistrationButtonBy => By.XPath("//button[.='Complete Registration']");
        protected By warningMessageBy => 
            By.XPath("//div[contains(.,'Based on the information provided, we consider that trading on margin is not appropriate for you.')]");

        public override void WaitForPageLoading()
        {
            base.WaitForPageLoading();
            WaitForVisible(headerBy, WaitTime.ThirtySec);
            WaitForVisible(warningMessageBy, WaitTime.ThirtySec);
        }

        public bool IsWarningPageDisplayed()
        {
            return IsElementExist(headerBy, timeoutInSec: WaitTime.TenSec);
        }

        public void Agree()
        {
            Driver.FindElement(iAgreeButtonBy).Click();
        }

        public void CompleteRegistration()
        {
            var registrationButton = Driver.FindElement(completeRegistrationButtonBy);
            registrationButton.Click();
            registrationButton.WaitForDisappear();
        }
    }
}
