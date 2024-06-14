using Core.Helpers;
using Core.Pages.AvaTrade.Registration;
using OpenQA.Selenium;
using Tools;

namespace Core.Pages.AvaTrade.MainWebSite
{
    /// <summary>
    /// Home AvaTrade web-page
    /// </summary>
    public class ATHomePage : BasePage
    {
        protected By registerAccountButtonBy => By.XPath("//a[@href='/trading-account']");
        protected By acceptCookiesButtonBy => By.Id("ava_allow_all_c");

        public override void WaitForPageLoading()
        {
            base.WaitForPageLoading();
        }

        public void AcceptCookies()
        {
            AllowCookies();

            //often there is another acceptCookies window appear
            AllowCookies();
        }

        public void AllowCookies()
        {
            try
            {
                WaitHelper.WaitForVisible(acceptCookiesButtonBy, WaitTime.TwentySec);

                var acceptCookiesButton = Driver.FindElement(acceptCookiesButtonBy);
                acceptCookiesButton.Click();
                acceptCookiesButton.WaitForDisappear();

                //page is reloading when cookies are accepted
                WaitForPageLoading();
            }
            catch (WaitException)
            {
                Console.WriteLine("No cookies window appear");
            }
        }

        public void InitiateAccountRegistration()
        {
            WaitForVisible(registerAccountButtonBy);
            var registerAccountButton = Driver.FindElement(registerAccountButtonBy);
            registerAccountButton.Click();

            new ATInitialSignUpPage().WaitForPageLoading();
        }
    }
}
