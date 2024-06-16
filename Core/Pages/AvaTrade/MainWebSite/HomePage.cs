using Core.Helpers;
using Core.Helpers.Controls;
using Core.Pages.AvaTrade.Registration;
using OpenQA.Selenium;

namespace Core.Pages.AvaTrade.MainWebSite
{
    /// <summary>
    /// Home AvaTrade web-page
    /// </summary>
    public class HomePage : BasePage
    {
        protected ButtonControl registerAccountButton => new ButtonControl(By.XPath("//a[@href='/trading-account']"));
        protected ButtonControl acceptCookiesButton => new ButtonControl(By.Id("ava_allow_all_c"));

        public override void WaitForPageLoading()
        {
            base.WaitForPageLoading();
        }

        public void AcceptCookies()
        {
            AllowCookies("first");

            //often there is another acceptCookies window appear
            AllowCookies("second");
        }

        public void AllowCookies(string attempt)
        {
            try
            {
                acceptCookiesButton.WaitForVisible();
                acceptCookiesButton.Click();
                acceptCookiesButton.WaitForDisappear();

                //page is reloading when cookies are accepted
                WaitForPageLoading();
            }
            catch (WaitException)
            {
                Console.WriteLine($"No {attempt} cookies window appear");
            }
        }

        public void InitiateAccountRegistration()
        {
            registerAccountButton.WaitForVisible();
            registerAccountButton.Click();

            new InitialSignUpPage().WaitForPageLoading();
        }
    }
}
