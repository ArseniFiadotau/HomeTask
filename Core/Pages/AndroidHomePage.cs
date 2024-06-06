using Core.Helpers;
using OpenQA.Selenium;
using Tools;

namespace Core.Pages
{
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
