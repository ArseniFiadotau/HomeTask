using Core.Helpers;
using OpenQA.Selenium;
using Tools;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Core.Pages.AvaTrade.TradingPlatform
{
    /// <summary>
    /// 'Terms and Conditions' page that appear at the end of registration process
    /// </summary>
    public class ATTermsAndConditionsPage : BasePage
    {
        //TODO: Add verification that this is toggled
        protected By NotUsCitizenToggleBy => By.CssSelector("input[name='NoUsaCitizenship']");
        protected By AcceptTermsToggleBy => By.XPath("//span[text()='I have read, understood and accepted the']");

        protected By FinishButtonBy => By.CssSelector("button[type='submit']");

        public override void WaitForPageLoading()
        {
            base.WaitForPageLoading();
            Driver.SwitchTo().DefaultContent();

            new WebDriverWait(Driver, TimeSpan.FromSeconds(WaitTime.TwentySec))
                .Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.CssSelector("iframe[data-qa='iframe__container']")));

            WaitForVisible(FinishButtonBy, WaitTime.ThirtySec);
            WaitForVisible(AcceptTermsToggleBy, WaitTime.ThirtySec);
        }

        public void CompleteRegistration()
        {
            var toggle = Driver.FindElement(AcceptTermsToggleBy);
            toggle.Click();

            var button = Driver.FindElement(FinishButtonBy);
            button.Click();
            button.WaitForDisappear(WaitTime.ThirtySec);
        }

        //TODO: Add verification for downloaded PDF document
    }
}
