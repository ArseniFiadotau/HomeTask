using OpenQA.Selenium;
using Tools;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using Core.Helpers.Controls;

namespace Core.Pages.AvaTrade.TradingPlatform.Registration
{
    /// <summary>
    /// 'Terms and Conditions' page that appear at the end of registration process
    /// </summary>
    public class TermsAndConditionsPage : BasePage
    {
        //TODO: Add verification that this is toggled
        protected By NotUsCitizenToggleBy => By.CssSelector("input[name='NoUsaCitizenship']");
        protected By AcceptTermsToggleBy => By.XPath("//span[text()='I have read, understood and accepted the']");

        protected ButtonControl FinishButton => new ButtonControl(By.CssSelector("button[type='submit']"));

        public override void WaitForPageLoading()
        {
            base.WaitForPageLoading();
            Driver.SwitchTo().DefaultContent();

            new WebDriverWait(Driver, TimeSpan.FromSeconds(WaitTime.TwentySec))
                .Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.CssSelector("iframe[data-qa='iframe__container']")));

            FinishButton.WaitForVisible(WaitTime.ThirtySec);
            WaitForVisible(AcceptTermsToggleBy, WaitTime.ThirtySec);
        }

        public void CompleteRegistration()
        {
            var toggle = Driver.FindElement(AcceptTermsToggleBy);
            toggle.Click();

            FinishButton.Click();
            FinishButton.WaitForDisappear(WaitTime.ThirtySec);
        }

        //TODO: Add verification for downloaded PDF document
    }
}
