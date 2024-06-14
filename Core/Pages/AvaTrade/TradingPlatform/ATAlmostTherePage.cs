using Core.Helpers;
using OpenQA.Selenium;
using Tools;

namespace Core.Pages.AvaTrade.TradingPlatform
{
    /// <summary>
    /// 'Almost there' page or dialog (need more time to define) that contains either ability to verify user
    /// or top-up the deposits, depending on user data type
    /// </summary>
    public class ATAlmostTherePage : BasePage
    {
        protected By headerBy => By.XPath("//p[.='Almost There']");
        protected By closeButtonBy => By.Id("typ-close-icon");

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
    }
}
