using OpenQA.Selenium;
using Tools;

namespace Core.Pages.AvaTrade.Registration
{
    public class ATPersonalDetails25Page: BasePage
    {
        protected By progressBar = By.XPath("//android.widget.ProgressBar[@text=\"25.0\"]");
        protected By FirstNameTextBoxBy => By.XPath("//android.view.View[@text=\"First Name\"]/../../android.widget.EditText");
        protected By LastNameTextBoxBy => By.XPath("//android.view.View[@text=\"Last Name\"]/../../android.widget.EditText");

        protected By DayTextBoxBy => By.XPath("//android.widget.EditText[@resource-id=\"date-day\"]");
        protected By DateTextBoxBy => By.XPath("//android.widget.EditText[@resource-id=\"date-month\"]");
        protected By YearTextBoxBy => By.XPath("//android.widget.EditText[@resource-id=\"date-year\"]");

        protected By PhoneTextBoxBy => By.XPath("//android.widget.EditText[@resource-id=\"phone-number-input\"]");

        protected By ContinueButtonBy => By.XPath("//android.widget.Button[@text=\"Continue\"]");

        public override void WaitForPageLoading()
        {
            WaitForVisible(progressBar, WaitTime.ThirtySec);
            WaitForVisible(PhoneTextBoxBy, WaitTime.ThirtySec);
            WaitForVisible(ContinueButtonBy, WaitTime.ThirtySec);
        }

    }
}
