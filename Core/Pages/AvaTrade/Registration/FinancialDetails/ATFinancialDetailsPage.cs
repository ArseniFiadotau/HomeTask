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
    public class ATFinancialDetailsPage : BasePage
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

        protected By ContinueButtonBy => By.CssSelector("button[type='submit']");

        public override void WaitForPageLoading()
        {
            PrimaryOccupationDropDown.WaitForVisible(WaitTime.ThirtySec);
            WaitForVisible(ContinueButtonBy, WaitTime.ThirtySec);
        }

        public void FillPageDataAndContinue(PersonData pd)
        {
            PrimaryOccupationDropDown.Select(pd.PrimaryOccupation.GetStringValue());
            EmploymentDropDown.Select(pd.EmploymentStatus.GetStringValue());
            SourceOfFundsDropDown.Select(pd.SourceOfFunds.GetStringValue());
            EstimatedAnnualIncomeDropDown.Select(pd.EstimatedAnnualIncome.GetStringValue()); 
            EstimatedValueSavingsDropDown.Select(pd.EstimatedValueSavings.GetStringValue());
            FinancialRiskDropDown.Select(pd.FinancialRisk.GetStringValue());

            var button = Driver.FindElement(ContinueButtonBy);
            button.Click();
            button.WaitForDisappear();
        }
    }
}
