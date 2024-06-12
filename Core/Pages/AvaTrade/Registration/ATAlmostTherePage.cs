using Core.Helpers;
using OpenQA.Selenium;
using Tools;

namespace Core.Pages
{
    /// <summary>
    /// 'Almost there' page or dialog (need more time to define) that contains either ability to verify user
    /// or top-up the deposits, depending on user data type
    /// </summary>
    public class ATAlmostTherePage : BasePage
    {
        protected By headerBy => By.XPath("//android.widget.TextView[@text=\"Almost There\"]");
        protected By closeButtonBy => By.XPath("//android.widget.Button[@resource-id=\"typ-close-icon\"]");

        public override void WaitForPageLoading()
        {
            WaitForVisible(headerBy, WaitTime.ThirtySec);
        }

        public void CloseDialog()
        {
            var closeDialogButton = Driver.FindElement(closeButtonBy);
            closeDialogButton.Click();
            closeDialogButton.WaitForDisappear(WaitTime.ThirtySec);
        }
    }
}
