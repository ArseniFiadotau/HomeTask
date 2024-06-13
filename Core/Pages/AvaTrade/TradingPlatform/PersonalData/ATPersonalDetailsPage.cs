using Core.Components;
using Core.Helpers;
using Core.Helpers.Controls;
using Core.Pages.AvaTrade.Registration.FinancialDetails;
using OpenQA.Selenium;
using Tools;

namespace Core.Pages.AvaTrade.TradingPlatform.PersonalData
{
    /// <summary>
    /// Personal Details page, opens when user defines email and password on Initial Sign-Up page
    /// </summary>
    public class ATPersonalDetailsPage : BasePage
    {
        private By iFrameBy = By.CssSelector("iframe[data-qa='iframe__container']");

        private By FirstNameTextBoxBy => By.CssSelector("input[name='FirstName']");
        private By LastNameTextBoxBy => By.CssSelector("input[name='LastName']");
        private By DayTextBoxBy => By.CssSelector("input[name='date-of-birth-day']");
        private By MonthTextBoxBy => By.CssSelector("input[name='date-of-birth-month']");
        private By YearTextBoxBy => By.CssSelector("input[name='date-of-birth-year']");
        protected ComboBoxControl CountryComboBox => new ComboBoxControl("//div[@role='combobox'][.//input[@name='Country']]");
        private By PhoneTextBoxBy => By.CssSelector("input[name='Phone']");

        private By CityTextBoxBy => By.CssSelector("input[name='City']");
        private By StreetNameTextBoxBy => By.CssSelector("input[name='Street']");
        private By BuldingNumberTextBoxBy => By.CssSelector("input[name='BuildingNumber']");
        private By PostalCodeTextBoxBy => By.CssSelector("input[name='ZipCode']");

        protected TextBoxControl FirstNameTextBox => new TextBoxControl(FirstNameTextBoxBy);
        protected TextBoxControl LastNameTextBox => new TextBoxControl(LastNameTextBoxBy);
        protected TextBoxControl DayTextBox => new TextBoxControl(DayTextBoxBy);
        protected TextBoxControl MonthTextBox => new TextBoxControl(MonthTextBoxBy);
        protected TextBoxControl YearTextBox => new TextBoxControl(YearTextBoxBy);
        protected TextBoxControl PhoneTextBox => new TextBoxControl(PhoneTextBoxBy);

        protected TextBoxControl CityTextBox => new TextBoxControl(CityTextBoxBy);
        protected TextBoxControl StreetNameTextBox => new TextBoxControl(StreetNameTextBoxBy);
        protected TextBoxControl BuildingNumberTextBox => new TextBoxControl(BuldingNumberTextBoxBy);
        protected TextBoxControl PostalCodeTextBox => new TextBoxControl(PostalCodeTextBoxBy);

        protected By ContinueButtonBy => By.CssSelector("button[type='submit']");

        public void SwitchToIFrame()
        {
            //time is so big because user is switched to trading platform
            WaitForVisible(iFrameBy, WaitTime.OneMin);

            var iframe = Driver.FindElement(iFrameBy);
            Driver.SwitchTo().Frame(iframe);
        }

        public override void WaitForPageLoading()
        {
            SwitchToIFrame();

            FirstNameTextBox.WaitForVisible(WaitTime.ThirtySec);

            CityTextBox.WaitForVisible(WaitTime.ThirtySec);
            WaitForVisible(ContinueButtonBy, WaitTime.ThirtySec);
        }

        public void FillPageDataAndContinue(PersonData data)
        {
            FirstNameTextBox.ClickAndSendKeys(data.FirstName);
            LastNameTextBox.ClickAndSendKeys(data.LastName);

            DayTextBox.SendKeys(data.DateOfBirth.Day.ToString());
            MonthTextBox.SendKeys(data.DateOfBirth.Month.ToString());

            // this is a different implementation that allow to trigger field validation, because just SendKeys doesn't trigger it
            // and this stops registration process
            YearTextBox.SendKeysWithActions(data.DateOfBirth.Year.ToString());

            CountryComboBox.Select(data.Country);
            ProgressBar.WaitForVisible();
            ProgressBar.WaitForDisappear();

            CityTextBox.ClickAndSendKeys(data.City);
            StreetNameTextBox.ClickAndSendKeys(data.StreetName);
            BuildingNumberTextBox.ClickAndSendKeys(data.BuildingNumber);
            PostalCodeTextBox.ClickAndSendKeys(data.PostalCode);

            PhoneTextBox.ClickAndSendKeys(data.PhoneNumber);

            var button = Driver.FindElement(ContinueButtonBy);
            button.Click();
            button.WaitForDisappear(WaitTime.ThirtySec);

            new ATFinancialDetailsPage().WaitForPageLoading();
        }
    }
}
