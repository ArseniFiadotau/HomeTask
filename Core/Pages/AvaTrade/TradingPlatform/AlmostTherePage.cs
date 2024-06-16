using Core.Helpers;
using Core.Helpers.Controls;
using Core.Pages.AvaTrade.TradingPlatform.Verification;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Tools;

namespace Core.Pages.AvaTrade.TradingPlatform
{
    /// <summary>
    /// 'Almost there' page or dialog (need more time to define) that contains either ability to verify user
    /// or top-up the deposits, depending on user data type
    /// </summary>
    public class AlmostTherePage : BasePage
    {
        protected By headerBy => By.XPath("//p[.='Almost There']");
        protected By closeButtonBy => By.Id("typ-close-icon");
        protected By verifyAccountButtonBy => By.XPath("//div[@class='action-button'][.//span[.='Verify your account']]");
        protected ButtonControl verifyAccountButton => new ButtonControl(verifyAccountButtonBy);

        public override void WaitForPageLoading()
        {
            base.WaitForPageLoading();
            WaitForVisible(headerBy, WaitTime.ThirtySec);
        }

        public void CloseDialog()
        {
            var closeDialogButton = Driver.FindElement(closeButtonBy);
            closeDialogButton.Click();
            WaitHelper.WaitForDisappear(closeButtonBy);
        }

        public bool IsVerificationButtonVisible() => IsElementExist(verifyAccountButtonBy, timeoutInSec: WaitTime.TenSec);

        public void OpenVerificationPage()
        {
            verifyAccountButton.Click();
            verifyAccountButton.WaitForDisappear();

            new WebDriverWait(Driver, TimeSpan.FromSeconds(WaitTime.TwentySec))
                .Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.CssSelector("iframe[data-qa='iframe__container']")));
        }
    }
}
