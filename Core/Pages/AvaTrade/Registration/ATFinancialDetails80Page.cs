using OpenQA.Selenium;
using Tools;

namespace Core.Pages.AvaTrade.Registration
{
    public class ATFinancialDetails80Page : BasePage
    {
        protected By progressBar = By.XPath("//android.widget.ProgressBar[@text=\"80.0\"]");

        // implement here three selects for the following texts as on initial page

        //What is the estimated value of your savings & investments?
        //What level of financial risk are you comfortable with?

        protected By ContinueButtonBy => By.XPath("//android.widget.Button[@text=\"Continue\"]");

        public override void WaitForPageLoading()
        {
            WaitForVisible(progressBar, WaitTime.ThirtySec);
            WaitForVisible(ContinueButtonBy, WaitTime.ThirtySec);
        }
    }
}
