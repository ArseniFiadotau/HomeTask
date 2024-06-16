using Core.Helpers.Controls;
using OpenQA.Selenium;
using Tools;

namespace Core.Pages.AvaTrade.TradingPlatform.Registration
{
    /// <summary>
    /// 'WarningPage' page that appear when user enters not valid options for optimal trading 
    /// </summary>
    public class WarningPage : BasePage
    {
        protected By headerBy => By.XPath("//span[.='Warning']");
        protected ButtonControl AgreeButton => new ButtonControl(By.XPath("//label[.//span[.='I agree']]"));
        protected ButtonControl CompleteRegistrationButton => new ButtonControl(By.XPath("//button[.='Complete Registration']"));
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
            AgreeButton.Click();
        }

        public void CompleteRegistration()
        {
            CompleteRegistrationButton.Click();
            CompleteRegistrationButton.WaitForDisappear();
        }
    }
}
