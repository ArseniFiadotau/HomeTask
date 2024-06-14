using OpenQA.Selenium;
using Tools;
using Core.Helpers;
using Core.Helpers.Controls;
using Core.Pages.AvaTrade.TradingPlatform.PersonalData;

namespace Core.Pages.AvaTrade.Registration
{
    /// <summary>
    /// Initial Sign-Up page, that is displayed after 'Create new account' or 'Sign-up' buttons on the login screen
    /// </summary>
    public class ATInitialSignUpPage : BasePage
    {
        private readonly By emailBy = By.Id("input-email");
        private readonly By passwordBy = By.Id("input-password");

        protected TextBoxControl EmailTextBox => new TextBoxControl(emailBy);
        protected TextBoxControl PasswordTextBox => new TextBoxControl(passwordBy);
        protected By CreateMyAccountButtonBy => By.XPath("//button[.//span[.='Create My Account']]");

        public override void WaitForPageLoading()
        {
            base.WaitForPageLoading();
            EmailTextBox.WaitForVisible();
            PasswordTextBox.WaitForVisible();            
        }

        public void FillPageDataAndCreateAccount(PersonData data)
        {
            EmailTextBox.ClickAndSendKeys(data.Email);
            PasswordTextBox.ClickAndSendKeys(data.Password);

            var button = Driver.FindElement(CreateMyAccountButtonBy);
            button.Click();
            button.WaitForDisappear(WaitTime.ThirtySec);

            new ATPersonalDetailsPage().WaitForPageLoading();
        }
    }
}
