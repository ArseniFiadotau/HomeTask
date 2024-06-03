using OpenQA.Selenium;
using Tools;

namespace Core.Pages
{
    public class ATAlmostTherePage : BasePage
    {
        protected By headerBy => By.XPath("//android.widget.TextView[@text=\"Almost There\"]");
        //just hit close button and wait for main page to load
        protected By closeButtonBy => By.XPath("//android.widget.Button[@resource-id=\"typ-close-icon\"]");

        public override void WaitForPageLoading()
        {
            WaitForVisible(headerBy, WaitTime.ThirtySec);
        }
    }
}
