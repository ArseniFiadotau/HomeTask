using Core.Helpers;
using Core.Helpers.Controls;
using OpenQA.Selenium;
using Tools;

namespace Core.Pages.AvaTrade.TradingPlatform.FinancialDetails
{
    /// <summary>
    /// Trading Experience registration page
    /// </summary>
    public class TradingExpiriencePage : BasePage
    {
        protected ButtonControl YesButton => new ButtonControl(By.CssSelector("label[for='option-1_84-1']"));

        protected DropDownControl NumOfTimesTradedinForexCfdsDropDown =>
            new DropDownControl("//div[@data-automation='NumOfTimesTradedinForexCfds']");
        protected DropDownControl WhatWasTheAverageSizeOfTradesDropDown =>
            new DropDownControl("//div[@data-automation='WhatWasTheAverageSizeOfTrades']");
        protected DropDownControl TradingWithLeverageAppliesDropDown =>
            new DropDownControl("//div[@data-automation='TradingWithLeverageApplies']");
        protected DropDownControl TradingWithLeverageMaximumPositionDropDown =>
            new DropDownControl("//div[@data-automation='TradingWithLeverageMaximumPosition']");
        protected DropDownControl OpenPositionAutomaticallyCloseDropDown =>
            new DropDownControl("//div[@data-automation='OpenPositionAutomaticallyClose']");
        protected DropDownControl WhyTradeWithUsDropDown =>
            new DropDownControl("//div[@data-automation='WhyTradeWithUs']");
        protected By IUnderstandTransactionNatureBy => By.CssSelector("label[for='question-11_297']");

        protected ButtonControl ContinueButton => new ButtonControl(By.CssSelector("button[type='submit']"));

        public override void WaitForPageLoading()
        {
            base.WaitForPageLoading();
            YesButton.WaitForVisible();
            TradingWithLeverageAppliesDropDown.WaitForVisible(WaitTime.ThirtySec);
            ContinueButton.WaitForVisible(WaitTime.ThirtySec);
        }

        public void FillPageDataAndContinue(PersonData pd)
        {
            YesButton.Click();

            NumOfTimesTradedinForexCfdsDropDown.Select(pd.TradingExperienceExtent.GetStringValue());
            WhatWasTheAverageSizeOfTradesDropDown.Select(pd.EstimatedValueOfTrades.GetStringValue());
            TradingWithLeverageAppliesDropDown.Select(pd.TradingWithLeverageStatement.GetStringValue());
            TradingWithLeverageMaximumPositionDropDown.Select(pd.MaximumSizePosition.GetStringValue());
            OpenPositionAutomaticallyCloseDropDown.Select(pd.OpenPositionMayClose.GetStringValue());
            WhyTradeWithUsDropDown.Select(pd.PrimaryPurpose.GetStringValue());

            var confirmButton = Driver.FindElement(IUnderstandTransactionNatureBy);
            confirmButton.Click();
            
            ContinueButton.Click();
        }
    }
}
