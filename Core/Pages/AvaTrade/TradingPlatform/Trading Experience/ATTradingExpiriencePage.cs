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
        protected By YesButtonBy => By.CssSelector("label[for='option-1_84-1']");
        protected By NoButtonBy => By.CssSelector("label[for='option-1_84-2']");

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

            NumOfTimesTradedinForexCfdsDropDown.Select(pd.TradingExperienceExtent.GetStringValue());
            WhatWasTheAverageSizeOfTradesDropDown.Select(pd.EstimatedValueOfTrades.GetStringValue());
            TradingWithLeverageAppliesDropDown.Select(pd.TradingWithLeverageStatement.GetStringValue());
            TradingWithLeverageMaximumPositionDropDown.Select(pd.MaximumSizePosition.GetStringValue());
            OpenPositionAutomaticallyCloseDropDown.Select(pd.OpenPositionMayClose.GetStringValue());
            WhyTradeWithUsDropDown.Select(pd.PrimaryPurpose.GetStringValue());

            var confirmButton = Driver.FindElement(IUnderstandTransactionNatureBy);
            confirmButton.Click();
            
            var button = Driver.FindElement(ContinueButtonBy);
            button.Click();
            button.WaitForDisappear();
        }
    }
}
