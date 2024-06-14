using Core.Helpers;
using Core.Helpers.Controls;
using OpenQA.Selenium;
using Tools;
using static Core.Data.RegistrationEnums;

namespace Core.Pages.AvaTrade.TradingPlatform.FinancialDetails
{
    /// <summary>
    /// Trading Experience registration page
    /// </summary>
    public class ATTradingExpiriencePage : BasePage
    {
        protected By YesButtonBy => By.CssSelector("for='option-1_84-1'");
        protected By NoButtonBy => By.CssSelector("for='option-1_84-2'");

        protected DropDownControl TradingWithLeverageAppliesDropDown =>
            new DropDownControl("//div[@data-automation='TradingWithLeverageApplies']");
        protected DropDownControl TradingWithLeverageMaximumPositionDropDown =>
            new DropDownControl("//div[@data-automation='TradingWithLeverageMaximumPosition']");
        protected DropDownControl OpenPositionAutomaticallyCloseDropDown =>
            new DropDownControl("//div[@data-automation='OpenPositionAutomaticallyClose']");
        protected DropDownControl WhyTradeWithUsDropDown =>
            new DropDownControl("//div[@data-automation='WhyTradeWithUs']");
        protected By IUnderstandTransactionNatureBy => By.CssSelector("label[for='question-11_297']");

        protected By ContinueButtonBy => By.CssSelector("button[type='submit']");

        public override void WaitForPageLoading()
        {
            base.WaitForPageLoading();
            WaitForVisible(YesButtonBy);
            TradingWithLeverageAppliesDropDown.WaitForVisible(WaitTime.ThirtySec);
            WaitForVisible(ContinueButtonBy, WaitTime.ThirtySec);
        }

        public void FillPageDataAndContinue(PersonData pd)
        {
            var yesButton = Driver.FindElement(YesButtonBy);
            yesButton.Click();

            TradingWithLeverageAppliesDropDown.Select(pd.PrimaryOccupation.GetStringValue());
            TradingWithLeverageMaximumPositionDropDown.Select(pd.EmploymentStatus.GetStringValue());
            OpenPositionAutomaticallyCloseDropDown.Select(pd.SourceOfFunds.GetStringValue());
            WhyTradeWithUsDropDown.Select(pd.EstimatedAnnualIncome.GetStringValue());

            var button = Driver.FindElement(ContinueButtonBy);
            button.Click();
            button.WaitForDisappear();
        }
    }
}
