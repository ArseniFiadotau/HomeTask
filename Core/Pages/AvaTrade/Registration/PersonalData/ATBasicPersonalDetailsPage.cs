using Core.Helpers;
using Core.Helpers.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using Tools;

namespace Core.Pages.AvaTrade.Registration.PersonalData
{
    public class ATBasicPersonalDetailsPage : BasePage
    {
        private By FirstNameTextBoxBy => By.XPath("//android.view.View[@text='First Name']/../../android.widget.EditText");
        private By LastNameTextBoxBy => By.XPath("//android.view.View[@text='Last Name']/../../android.widget.EditText");
        private By DayTextBoxBy => MobileBy.XPath("//android.view.View[@text='Date of Birth']/..//android.widget.EditText[1]");
        private By MonthTextBoxBy => MobileBy.XPath("//android.view.View[@text='Date of Birth']/..//android.widget.EditText[2]");
        private By YearTextBoxBy => MobileBy.XPath("//android.view.View[@text='Date of Birth']/..//android.widget.EditText[3]");
        private By PhoneTextBoxBy => MobileBy.XPath("//android.view.View[@text='Phone Number']/../android.widget.EditText");

        protected TextBoxControl FirstNameTextBox => new TextBoxControl(FirstNameTextBoxBy);
        protected TextBoxControl LastNameTextBox => new TextBoxControl(LastNameTextBoxBy);
        protected TextBoxControl DayTextBox => new TextBoxControl(DayTextBoxBy);
        protected TextBoxControl MonthTextBox => new TextBoxControl(MonthTextBoxBy);
        protected TextBoxControl YearTextBox => new TextBoxControl(YearTextBoxBy);
        protected TextBoxControl PhoneTextBox => new TextBoxControl(PhoneTextBoxBy);

        protected By ContinueButtonBy => By.XPath("//android.widget.Button[@text='Continue']");

        public override void WaitForPageLoading()
        {
            WaitForVisible(ContinueButtonBy, WaitTime.ThirtySec);
            PhoneTextBox.WaitForVisible(WaitTime.OneMin);
        }

        public void FillPageDataAndContinue(string firstName, string lastName, DateTime date, string phone)
        {
            FirstNameTextBox.ClickAndSendKeys(firstName);
            LastNameTextBox.ClickAndSendKeys(lastName);
            
            DayTextBox.SendKeys(date.Day.ToString());
            MonthTextBox.SendKeys(date.Month.ToString());

            YearTextBox.SendKeysWithActions(date.Year.ToString());

            PhoneTextBox.ClickAndSendKeys(phone);

            var button = Driver.FindElement(ContinueButtonBy);
            button.Click();
            button.WaitForDisappear();
        }
    }
}
