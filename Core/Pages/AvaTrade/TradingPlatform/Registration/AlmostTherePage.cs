using Core.Helpers.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Tools;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Core.Pages.AvaTrade.TradingPlatform.Registration
{
    /// <summary>
    /// 'Almost there' page that contains either ability to verify user or top-up the deposits, depending on user data type
    /// </summary>
    public class AlmostTherePage : BasePage
    {
        protected By headerBy => By.XPath("//p[.='Almost There']");
        protected By verifyAccountButtonBy => By.XPath("//div[@class='action-button'][.//span[.='Verify your account']]");
        protected ButtonControl VerifyAccountButton => new ButtonControl(verifyAccountButtonBy);
        protected ButtonControl CloseButton => new ButtonControl(By.Id("typ-close-icon"));

        public override void WaitForPageLoading()
        {
            base.WaitForPageLoading();
            WaitForVisible(headerBy, WaitTime.ThirtySec);
        }

        public void CloseDialog()
        {
            CloseButton.Click();
            CloseButton.WaitForDisappear();
        }

        public bool IsVerificationButtonVisible() => IsElementExist(verifyAccountButtonBy, timeoutInSec: WaitTime.TenSec);

        public void OpenVerificationPage()
        {
            VerifyAccountButton.Click();
            VerifyAccountButton.WaitForDisappear();

            new WebDriverWait(Driver, TimeSpan.FromSeconds(WaitTime.TwentySec))
                .Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.CssSelector("iframe[data-qa='iframe__container']")));
        }
    }
}
