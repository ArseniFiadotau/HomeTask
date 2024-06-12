using Core.Helpers;
using Tools;

namespace Core.Pages
{
    /// <summary>
    /// Android home page with AvaTrade app on it
    /// </summary>
    public class AndroidHomePage: BasePage
    {
        public void OpenAvaTradeApp()
        {
            var avaTradeApp = Driver.FindElementByAccessibilityId("AvaTrade"); 
            avaTradeApp.Click();

            avaTradeApp.WaitForDisappear(WaitTime.ThirtySec);
        }
    }
}
