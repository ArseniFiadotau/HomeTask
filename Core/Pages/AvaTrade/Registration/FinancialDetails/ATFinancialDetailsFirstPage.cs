using Core.Helpers;
using Core.Helpers.Controls;
using OpenQA.Selenium;
using Tools;
using static Core.Data.RegistrationEnums;

namespace Core.Pages.AvaTrade.Registration.FinancialDetails
{
    /// <summary>
    /// First page of Financial Details registration process, opens when Personal Data pages are completed
    /// </summary>
    public class ATFinancialDetailsFirstPage : BasePage
    {
        //TODO: Add progress bar validation based on PersonData.IsEducational field here and in other places
        //protected By progressBar = By.XPath("//android.widget.ProgressBar[@text=\"65.0\"]");

        protected DropDownControl PrimaryOccupationDropDown => 
            new DropDownControl("//android.view.View[./android.view.View[@text='What is your primary occupation?']]");
        protected DropDownControl EmploymentDropDown => 
            new DropDownControl("//android.view.View[./android.view.View[@text='Are you currently employed?']]");
        protected DropDownControl SourceOfFundsDropDown => 
            new DropDownControl("//android.view.View[./android.view.View[@text='What is the source of the funds you intend to invest?']]");
        protected DropDownControl EstimatedAnnualIncomeDropDown => 
            new DropDownControl("//android.view.View[./android.view.View[@text='What is your estimated annual income?']]");

        protected By ContinueButtonBy => By.XPath("//android.widget.Button[@text=\"Continue\"]");

        public override void WaitForPageLoading()
        {
            PrimaryOccupationDropDown.WaitForVisible(WaitTime.ThirtySec);
            WaitForVisible(ContinueButtonBy, WaitTime.ThirtySec);
        }

        public void FillPageDataAndContinue(PrimaryOccupation po, EmploymentStatus es, SourceOfFunds sof, EstimatedAnnualIncome eai)
        {
            PrimaryOccupationDropDown.Select(po.GetStringValue());
            EmploymentDropDown.Select(es.GetStringValue());
            SourceOfFundsDropDown.Select(sof.GetStringValue());
            EstimatedAnnualIncomeDropDown.Select(eai.GetStringValue());

            var button = Driver.FindElement(ContinueButtonBy);
            button.Click();
            button.WaitForDisappear();
        }
    }
}
