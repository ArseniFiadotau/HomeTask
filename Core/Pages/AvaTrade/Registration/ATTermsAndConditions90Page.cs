using OpenQA.Selenium;
using Tools;

namespace Core.Pages.AvaTrade.Registration
{
    public class ATTermsAndConditions90Page : BasePage
    {
        protected By progressBar = By.XPath("//android.widget.ProgressBar[@text=\"90.0\"]");

        //verify that this is toggled
        protected By NotUsCitizenToggleBy = By.XPath("//android.view.View[contains(@text,\"not a citizen or resident of the United States\")]/..//android.widget.ToggleButton");

        //toggle this one and click finish
        protected By AcceptTermsToggleBy = By.XPath("//android.widget.TextView[@text=\"I have read, understood and accepted the\"]/../..//android.widget.ToggleButton");
        protected By ReceiveUpdatesToggleBy = By.XPath("//android.view.View[@text=\"I would like to receive updates related to my account via WhatsApp\"]/..//android.widget.ToggleButton");

        // implement here three selects for the following texts as on initial page

        //What is your primary occupation?
        //Are you currently employed?
        //What is the source of the funds you intend to invest?
        //What is your estimated annual income?

        protected By FinishButtonBy => By.XPath("//android.widget.Button[@text=\"Finish\"]");

        public override void WaitForPageLoading()
        {
            WaitForVisible(progressBar, WaitTime.ThirtySec);
            WaitForVisible(ContinueButtonBy, WaitTime.ThirtySec);
        }
    }
}
