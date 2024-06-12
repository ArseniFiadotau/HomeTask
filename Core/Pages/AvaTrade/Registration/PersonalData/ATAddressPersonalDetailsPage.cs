using Core.Helpers;
using Core.Helpers.Controls;
using OpenQA.Selenium;
using Tools;

namespace Core.Pages.AvaTrade.Registration.PersonalData
{
    /// <summary>
    /// Page contains second step of Personal Data filling process
    /// </summary>
    public class ATAddressPersonalDetailsPage : BasePage
    {
        private By CityTextBoxBy => By.XPath("//android.view.View[@text=\"City\"]/../../android.widget.EditText");
        private By StreetNameTextBoxBy => By.XPath("//android.view.View[@text=\"Street Name\"]/../../android.widget.EditText");
        private By BuldingNumberTextBoxBy => By.XPath("//android.view.View[@text=\"Number\"]/../../android.widget.EditText");
        private By PostalCodeTextBoxBy => By.XPath("//android.view.View[@text=\"Postal Code\"]/../../android.widget.EditText");

        protected TextBoxControl CityTextBox => new TextBoxControl(CityTextBoxBy);
        protected TextBoxControl StreetNameTextBox => new TextBoxControl(StreetNameTextBoxBy);
        protected TextBoxControl BuildingNumberTextBox => new TextBoxControl(BuldingNumberTextBoxBy);
        protected TextBoxControl PostalCodeTextBox => new TextBoxControl(PostalCodeTextBoxBy);

        protected By ContinueButtonBy => By.XPath("//android.widget.Button[@text=\"Continue\"]");

        public override void WaitForPageLoading()
        {
            WaitForVisible(ContinueButtonBy, WaitTime.ThirtySec);
            PostalCodeTextBox.WaitForVisible(WaitTime.ThirtySec);
            CityTextBox.WaitForVisible(WaitTime.ThirtySec);
        }

        public void FillPageDataAndContinue(string city, string street, string buildingNumber, string postalCode)
        {
            CityTextBox.ClickAndSendKeys(city);
            StreetNameTextBox.ClickAndSendKeys(street);
            BuildingNumberTextBox.ClickAndSendKeys(buildingNumber);
            PostalCodeTextBox.ClickAndSendKeys(postalCode);

            //TODO: Add control Button and use it here and in other places
            var button = Driver.FindElement(ContinueButtonBy);
            button.Click();
            button.WaitForDisappear();
        }

        //Possible TODO: check that country combobox here has the same value as on previous page
    }
}
