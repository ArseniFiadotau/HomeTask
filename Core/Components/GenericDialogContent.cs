using OpenQA.Selenium;
using Core.Helpers;

namespace Core.Components
{
    /// <summary>
    /// Popup dialog
    /// </summary>
    public class PopupDialog
    {
        public static IWebDriver Driver = ChromeWebDriver.GetInstance();

        private By dialogBy = By.CssSelector("div[role='alertdialog']");
        private By closeBy = By.CssSelector("div[data-qa='tour-popup__start-close-icon']");
        private By textBy;

        public PopupDialog(string text)
        {
            textBy = By.XPath(string.Format("//div[@data-qa='tour-popup__start-text'][.='{0}']", text));
        }

        public void WaitForLoading()
        {
            WaitHelper.WaitForVisible(dialogBy);
            WaitHelper.WaitForVisible(textBy);
        }

        public void WaitForDisappear()
        {
            WaitHelper.WaitForDisappear(textBy);
        }

        public void Close()
        {
            Driver.FindElement(closeBy).Click();
            WaitForDisappear();
        }
    }
}
