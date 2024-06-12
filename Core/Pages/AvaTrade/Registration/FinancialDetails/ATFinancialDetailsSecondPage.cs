using Core.Helpers;
using Core.Helpers.Controls;
using OpenQA.Selenium;
using Tools;
using static Core.Data.RegistrationEnums;

namespace Core.Pages.AvaTrade.Registration.FinancialDetails
{
    /// <summary>
    /// Page that contain second part of Financial Data questions
    /// </summary>
    public class ATFinancialDetailsSecondPage : BasePage
    {
        protected DropDownControl EstimatedValueSavingsDropDown =>
            new DropDownControl("//android.view.View[./android.view.View[@text='What is the estimated value of your savings & investments?']]");
        protected DropDownControl FinancialRiskDropDown =>
            new DropDownControl("//android.view.View[./android.view.View[@text='What level of financial risk are you comfortable with?']]");
 
        protected By ContinueButtonBy => By.XPath("//android.widget.Button[@text=\"Continue\"]");

        public override void WaitForPageLoading()
        {
            EstimatedValueSavingsDropDown.WaitForVisible();
            WaitForVisible(ContinueButtonBy, WaitTime.ThirtySec);
        }

        public void FillPageDataAndContinue(EstimatedValueSavings evs, FinancialRisk fr)
        {
            EstimatedValueSavingsDropDown.Select(evs.GetStringValue());
            FinancialRiskDropDown.Select(fr.GetStringValue());

            var button = Driver.FindElement(ContinueButtonBy);
            button.Click();
            button.WaitForDisappear();
        }
    }
}
