using OpenQA.Selenium;
using Tools;

namespace Core.Pages.AvaTrade.Registration
{
    public class ATFinancialDetails65Page : BasePage
    {
        protected By progressBar = By.XPath("//android.widget.ProgressBar[@text=\"65.0\"]");

        // implement here three selects for the following texts as on initial page

        //What is your primary occupation?
        //Are you currently employed?
        //What is the source of the funds you intend to invest?
        //What is your estimated annual income?

        protected By ContinueButtonBy => By.XPath("//android.widget.Button[@text=\"Continue\"]");

        public override void WaitForPageLoading()
        {
            WaitForVisible(progressBar, WaitTime.ThirtySec);
            WaitForVisible(ContinueButtonBy, WaitTime.ThirtySec);
        }
    }
}
