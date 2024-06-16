using OpenQA.Selenium;
using Core.Helpers;

namespace Core.Components
{
    /// <summary>
    /// Modal dialog
    /// </summary>
    public class ModalDialog
    {
        public static IWebDriver Driver = ChromeWebDriver.GetInstance();

        private By dialogBy = By.CssSelector("div.modal-container");
        private By closeBy = By.CssSelector("//button[.='close']");
        private By saveAndExitBy = By.XPath("//button[./span[.=' Save and exit ']]");
        private By textBy;

        public ModalDialog(string text)
        {
            textBy = By.XPath(string.Format("//div[@class='text-block'][contains(.,'{0}')]", text));
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

        public void SaveAndExit()
        {
            Driver.FindElement(saveAndExitBy).Click();
            WaitForDisappear();
        }

        public void Close()
        {
            Driver.FindElement(closeBy).Click();
            WaitForDisappear();
        }
    }
}
