using OpenQA.Selenium;
using Tools;

namespace Core.Pages.AvaTrade.Registration
{
    public class ATPersonalDetails45Page : BasePage
    {
        protected By progressBar = By.XPath("//android.widget.ProgressBar[@text=\"45.0\"]");
        protected By CityTextBoxBy => By.XPath("//android.view.View[@text=\"First Name\"]/../../android.widget.EditText");
        protected By StreetNameTextBoxBy => By.XPath("//android.view.View[@text=\"Street Name\"]/../../android.widget.EditText");
        protected By NumberTextBoxBy => By.XPath("//android.view.View[@text=\"Number\"]/../../android.widget.EditText");
        protected By PostalCodeTextBoxBy => By.XPath("//android.view.View[@text=\"Postal Code\"]/../../android.widget.EditText");
        protected By ContinueButtonBy => By.XPath("//android.widget.Button[@text=\"Continue\"]");

        public override void WaitForPageLoading()
        {
            WaitForVisible(progressBar, WaitTime.ThirtySec);
            WaitForVisible(ContinueButtonBy, WaitTime.ThirtySec);
        }

        //check here country in the same control as was used on initial sign up page
    }
}
