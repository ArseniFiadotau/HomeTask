using Core.Helpers;
using Core.Helpers.Controls;
using OpenQA.Selenium;
using Tools;

namespace Core.Pages.AvaTrade.Registration.PersonalData
{
    public class ATAddressPersonalDetailsPage : BasePage
    {
        private By CityTextBoxBy => By.XPath("//android.view.View[@text=\"First Name\"]/../../android.widget.EditText");
        private By StreetNameTextBoxBy => By.XPath("//android.view.View[@text=\"Street Name\"]/../../android.widget.EditText");
        private By StreetNumberTextBoxBy => By.XPath("//android.view.View[@text=\"Number\"]/../../android.widget.EditText");
        private By PostalCodeTextBoxBy => By.XPath("//android.view.View[@text=\"Postal Code\"]/../../android.widget.EditText");

        protected TextBoxControl CityTextBox => new TextBoxControl(CityTextBoxBy);
        protected TextBoxControl StreetNameTextBox => new TextBoxControl(StreetNameTextBoxBy);
        protected TextBoxControl StreetNumberTextBox => new TextBoxControl(StreetNumberTextBoxBy);
        protected TextBoxControl PostalCodeTextBox => new TextBoxControl(PostalCodeTextBoxBy);

        protected By ContinueButtonBy => By.XPath("//android.widget.Button[@text=\"Continue\"]");

        public override void WaitForPageLoading()
        {
            WaitForVisible(ContinueButtonBy, WaitTime.ThirtySec);
        }

        public void FillPageDataAndContinue(string city, string street, string streetNumber, string postalCode)
        {
            CityTextBox.ClickAndSendKeys(city);
            StreetNameTextBox.ClickAndSendKeys(street);
            StreetNumberTextBox.ClickAndSendKeys(streetNumber);
            PostalCodeTextBox.ClickAndSendKeys(postalCode);

            var button = Driver.FindElement(ContinueButtonBy);
            button.Click();
            button.WaitForDisappear();
        }

        //Possible TODO: check that country combobox here has the same value as on previous page
    }
}
