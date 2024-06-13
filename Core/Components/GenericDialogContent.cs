using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;
using Core.Helpers;

namespace Core.Components
{
    /// <summary>
    /// TODO: Use it to work with AvaTrade dialogs
    /// </summary>
    public class GenericDialogContent
    {
        public static IWebDriver Driver = ChromeWebDriver.GetInstance();

        private By dialogBy = By.Id("com.avatrade.mobile:id/avatrade_generic_dialog_content");
        private By closeBy = By.Id("com.avatrade.mobile:id/walkthrough_skip");
        private By textBy;
        private By buttonBy;

        public GenericDialogContent(string text, string buttonText)
        {
            textBy = By.XPath(string.Format("//android.widget.TextView[contains(@text,'{0}')]", text));
            buttonBy = By.XPath(string.Format("//android.widget.Button[contains(@text,'{0}')]", text));
        }

        public void WaitForLoading()
        {
            Driver.FindElement(dialogBy).WaitForVisible();
            Driver.FindElement(textBy).WaitForVisible();
            Driver.FindElement(buttonBy).WaitForVisible();
        }

        public void WaitForDisappear()
        {
            Driver.FindElement(textBy).WaitForDisappear();
        }

        public void Close()
        {
            Driver.FindElement(closeBy).Click();
            WaitForDisappear();
        }
    }
}
