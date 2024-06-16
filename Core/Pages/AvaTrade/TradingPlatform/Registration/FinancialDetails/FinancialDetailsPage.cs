using Core.Helpers;
using Core.Helpers.Controls;
using OpenQA.Selenium;
using Tools;

namespace Core.Pages.AvaTrade.TradingPlatform.Registration.FinancialDetails
{
    /// <summary>
    /// Financial Details registration page  opens when Personal Data page is completed
    /// </summary>
    public class FinancialDetailsPage : BasePage
    {
        //TODO: Add progress bar validation based on PersonData.IsEducational field here and in other places
        //protected By progressBar = By.XPath("//android.widget.ProgressBar[@text=\"65.0\"]");

        protected DropDownControl PrimaryOccupationDropDown =>
            new DropDownControl("//div[@data-automation='OccupationOrBusiness']");
        protected DropDownControl EmploymentDropDown =>
            new DropDownControl("//div[@data-automation='EmploymentStatus']");
        protected DropDownControl SourceOfFundsDropDown =>
            new DropDownControl("//div[@data-automation='SourceOfTradeFunds']");
        protected DropDownControl EstimatedAnnualIncomeDropDown =>
            new DropDownControl("//div[@data-automation='EstimatedAnnualIncome']");
        protected DropDownControl EstimatedValueSavingsDropDown =>
            new DropDownControl("//div[@data-automation='SavingsAndInvestments']");
        protected DropDownControl FinancialRiskDropDown =>
            new DropDownControl("//div[@data-automation='AmountIntendInvestingEveryYear']");

        protected ButtonControl ContinueButton => new ButtonControl(By.CssSelector("button[type='submit']"));

        public override void WaitForPageLoading()
        {
            base.WaitForPageLoading();
            PrimaryOccupationDropDown.WaitForVisible(WaitTime.ThirtySec);
            ContinueButton.WaitForVisible(timeoutInSec: WaitTime.ThirtySec);
        }

        public void FillPageDataAndContinue(PersonData pd)
        {
            PrimaryOccupationDropDown.Select(pd.PrimaryOccupation.GetStringValue());
            EmploymentDropDown.Select(pd.EmploymentStatus.GetStringValue());
            SourceOfFundsDropDown.Select(pd.SourceOfFunds.GetStringValue());
            EstimatedAnnualIncomeDropDown.Select(pd.EstimatedAnnualIncome.GetStringValue());
            EstimatedValueSavingsDropDown.Select(pd.EstimatedValueSavings.GetStringValue());
            FinancialRiskDropDown.Select(pd.FinancialRisk.GetStringValue());

            ContinueButton.Click();
        }
    }
}
