using Core.Helpers;
using OpenQA.Selenium;
using Tools;

namespace Core.Pages.AvaTrade.Registration
{
    /// <summary>
    /// 'Terms and Conditions' page that appear at the end of registration process
    /// </summary>
    public class ATTermsAndConditionsPage : BasePage
    {
        //TODO: Add verification that this is toggled
        protected By NotUsCitizenToggleBy = By.XPath("//android.view.View[contains(@text,\"not a citizen or resident of the United States\")]/..//android.widget.ToggleButton");

        protected By AcceptTermsToggleBy = By.XPath("//android.widget.TextView[@text=\"I have read, understood and accepted the\"]/../..//android.widget.ToggleButton");
        
        protected By ReceiveUpdatesToggleBy = By.XPath("//android.view.View[@text=\"I would like to receive updates related to my account via WhatsApp\"]/..//android.widget.ToggleButton");

        protected By FinishButtonBy => By.XPath("//android.widget.Button[@text=\"Finish\"]");

        public override void WaitForPageLoading()
        {
            WaitForVisible(AcceptTermsToggleBy, WaitTime.ThirtySec);
            WaitForVisible(FinishButtonBy, WaitTime.ThirtySec);
        }

        public void CompleteRegistration()
        {
            var toggle = Driver.FindElement(AcceptTermsToggleBy);
            toggle.Click();
            
            // small workaround to provide reliable behavior
            // TODO: think of better idea here
            Thread.Sleep(3000);

            var button = Driver.FindElement(FinishButtonBy);
            button.Click();
            button.WaitForDisappear(WaitTime.ThirtySec);
        }

        //TODO: Add verification for downloaded PDF document
    }
}
