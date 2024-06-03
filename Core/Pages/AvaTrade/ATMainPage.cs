using OpenQA.Selenium;
using Tools;

namespace Core.Pages
{
    public class ATMainPage : BasePage
    {
        protected By logoBy => By.Id("com.avatrade.mobile:id/ava_main_toolbar_icon");

        public override void WaitForPageLoading()
        {
            WaitForVisible(logoBy, WaitTime.ThirtySec);
        }
    }
}
