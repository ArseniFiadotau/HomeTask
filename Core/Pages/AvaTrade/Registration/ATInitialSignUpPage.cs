using OpenQA.Selenium;
using Tools;
using Core.Helpers;
using Core.Helpers.Controls;
using OpenQA.Selenium.Appium.Android;

namespace Core.Pages.AvaTrade.Registration
{
    public class ATInitialSignUpPage : BasePage
    {
        private readonly By emailBy = By.XPath("//android.view.View[./android.view.View[@text='Email']]/android.widget.EditText");
        private readonly By passwordBy = By.XPath("//android.view.View[./android.view.View[@text='Password']]/android.widget.EditText");

        protected By SignUpForFreeBy => By.XPath("//android.widget.TextView[@text='Sign-Up for Free!']");
        protected ComboBoxControl CountryComboBox => new ComboBoxControl("//android.view.View[./android.view.View[@text='Country of Residence']]");
        protected TextBoxControl EmailTextBox => new TextBoxControl(emailBy);
        protected TextBoxControl PasswordTextBox => new TextBoxControl(passwordBy);
        protected By CreateMyAccountButtonBy => By.XPath("//android.widget.Button[@text='Create My Account']");

        public override void WaitForPageLoading()
        {
            WaitHelper.WaitForVisible(SignUpForFreeBy, WaitTime.OneMin);
            EmailTextBox.WaitForVisible();
            PasswordTextBox.WaitForVisible();
            CountryComboBox.WaitForVisible(WaitTime.ThirtySec);
        }

        public void FillPageDataAndCreateAccount(string country, string email, string password)
        {
            CountryComboBox.Select(country);
            EmailTextBox.ClickAndSendKeys(email);
            PasswordTextBox.ClickAndSendKeys(password);

            var button = Driver.FindElement(CreateMyAccountButtonBy);
            button.Click();
            button.WaitForDisappear();   
        }
    }
}
