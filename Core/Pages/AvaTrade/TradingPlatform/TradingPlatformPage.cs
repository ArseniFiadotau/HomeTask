using Core.Components;
using OpenQA.Selenium;

namespace Core.Pages.AvaTrade.TradingPlatform
{
    /// <summary>
    /// AvaTrade home page
    /// </summary>
    public class TradingPlatformPage : BasePage
    {
        private By leftSideIconsListBy => By.CssSelector("ul[data-qa='aside__list']");

        public override void WaitForPageLoading()
        {
            base.WaitForPageLoading();
            Driver.SwitchTo().DefaultContent();
        }

        public void CloseTutorialDialogIfAppears()
        {
            var dialog = new PopupDialog("You are all set to start trading on your Account. Start this easy 3-step tutorial and learn how to open a trade, monitor and modify your trades.");
            if (dialog.IsDisplayed())
            {
                dialog.WaitForLoading();
                dialog.Close();
            }
        }

        public bool AreIconsDisplayed()
        {
            return Driver.FindElements(leftSideIconsListBy).Count > 0;
        }
    }
}
