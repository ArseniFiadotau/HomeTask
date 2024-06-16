using Core.Components;
using Core.Helpers.Controls;
using Core.Pages.AvaTrade.TradingPlatform.FinancialDetails;
using Core.Pages.AvaTrade.TradingPlatform.Registration.FinancialDetails;
using OpenQA.Selenium;
using Tools;

namespace Core.Pages.AvaTrade.TradingPlatform.Registration.PersonalData
{
    /// <summary>
    /// Personal Details page, opens when user defines email and password on Initial Sign-Up page
    /// </summary>
    public class PersonalDetailsPage : BasePage
    {
        private By iFrameBy = By.CssSelector("iframe[data-qa='iframe__container']");

        protected ComboBoxControl CountryComboBox => new ComboBoxControl("//div[@role='combobox'][.//input[@name='Country']]");

        protected TextBoxControl FirstNameTextBox => new TextBoxControl(By.CssSelector("input[name='FirstName']"));
        protected TextBoxControl LastNameTextBox => new TextBoxControl(By.CssSelector("input[name='LastName']"));
        protected TextBoxControl DayTextBox => new TextBoxControl(By.CssSelector("input[name='date-of-birth-day']"));
        protected TextBoxControl MonthTextBox => new TextBoxControl(By.CssSelector("input[name='date-of-birth-month']"));
        protected TextBoxControl YearTextBox => new TextBoxControl(By.CssSelector("input[name='date-of-birth-year']"));
        protected TextBoxControl PhoneTextBox => new TextBoxControl(By.CssSelector("input[name='Phone']"));

        protected TextBoxControl CityTextBox => new TextBoxControl(By.CssSelector("input[name='City']"));
        protected TextBoxControl StreetNameTextBox => new TextBoxControl(By.CssSelector("input[name='Street']"));
        protected TextBoxControl BuildingNumberTextBox => new TextBoxControl(By.CssSelector("input[name='BuildingNumber']"));
        protected TextBoxControl PostalCodeTextBox => new TextBoxControl(By.CssSelector("input[name='ZipCode']"));

        protected ButtonControl ContinueButton => new ButtonControl(By.CssSelector("button[type='submit']"));

        public void SwitchToIFrame()
        {
            //wait time period is bigger because user is switched to trading platform
            WaitForVisible(iFrameBy, WaitTime.OneMin);

            var iframe = Driver.FindElement(iFrameBy);
            Driver.SwitchTo().Frame(iframe);
        }

        public override void WaitForPageLoading()
        {
            SwitchToIFrame();

            FirstNameTextBox.WaitForVisible(WaitTime.ThirtySec);

            CityTextBox.WaitForVisible(WaitTime.ThirtySec);
            ContinueButton.WaitForVisible(WaitTime.ThirtySec);
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

            ContinueButton.Click();

            new FinancialDetailsPage().WaitForPageLoading();
        }
    }
}
