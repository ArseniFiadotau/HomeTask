using OpenQA.Selenium;
using Tools;
using Core.Helpers;
using Core.Helpers.Controls;

namespace Core.Pages.AvaTrade.Registration
{
    public class ATInitialSignUpPage : BasePage
    {
        protected By SignUpForFreeBy => By.XPath("//android.widget.TextView[@text='Sign-Up for Free!']");
        protected ComboBox CountryComboBox => new ComboBox(By.XPath("//android.view.View[./android.view.View[@text='Country of Residence']]"));
        protected By EmailTextBoxBy => By.XPath("//android.view.View[./android.view.View[@text='Email']]/android.widget.EditText");
        protected By PasswordTextBoxBy => By.XPath("//android.view.View[./android.view.View[@text='Password']]/android.widget.EditText");
        protected By CreateMyAccountButtonBy => By.XPath("//android.widget.Button[@text='Create My Account']");

        public override void WaitForPageLoading()
        {
            WaitHelper.WaitForVisible(SignUpForFreeBy, WaitTime.OneMin);
            WaitHelper.WaitForVisible(CreateMyAccountButtonBy, WaitTime.OneMin);
        }

        public bool IsCountryDropdownVisible() => CountryComboBox.IsVisible();

        public void FulfillInitialInformation(string country, string email, string password)
        {
            CountryComboBox.Select(country);

            SendKeysToElementBy(EmailTextBoxBy, email);

            SendKeysToElementBy(PasswordTextBoxBy, password);

            // test passes, but this code "waitForDisappear" doesn't work
            var button = Driver.FindElement(CreateMyAccountButtonBy);
            button.Click();
            button.WaitForDisappear();
        }
    }
}
