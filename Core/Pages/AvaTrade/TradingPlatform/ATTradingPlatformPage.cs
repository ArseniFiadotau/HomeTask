using Core.Components;
using OpenQA.Selenium;

namespace Core.Pages.AvaTrade.TradingPlatform
{
    /// <summary>
    /// AvaTrade home page
    /// </summary>
    public class ATTradingPlatformPage : BasePage
    {
        private By leftSideIconsListBy => By.CssSelector("ul[data-qa='aside__list']");

        public override void WaitForPageLoading()
        {
            Driver.SwitchTo().DefaultContent();
        }

        public void CloseTutorialDialog()
        {
            var dialog = new PopupDialog("You are all set to start trading on your Account. Start this easy 3-step tutorial and learn how to open a trade, monitor and modify your trades.");
            dialog.WaitForLoading();
            dialog.Close();
        }

        public bool AreIconsDisplayed()
        {
            return Driver.FindElements(leftSideIconsListBy).Count > 0;
        }
    }
}
