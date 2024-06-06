using Core.Helpers;
using Tools;

namespace Core.Pages
{
    public class AndroidHomePage: BasePage
    {
        public void OpenAvaTradeApp()
        {
            var avaTradeApp = Driver.FindElementByAccessibilityId("AvaTrade");
            avaTradeApp.Click();
        }
    }
}
