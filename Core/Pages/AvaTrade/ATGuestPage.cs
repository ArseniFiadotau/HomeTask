using OpenQA.Selenium;
using Tools;

namespace Core.Pages
{
    /// <summary>
    /// Guest or Login page that is opened when non-authenticated user opens the app
    /// </summary>
    public class ATGuestPage : BasePage
    {
        protected By signUpButtonBy => By.Id("com.avatrade.mobile:id/login_sign_up");

        public override void WaitForPageLoading()
        {
            WaitForVisible(signUpButtonBy, WaitTime.ThirtySec);
        }

        public void InitiateAccountRegistration()
        {
            var createAccountButton = Driver.FindElement(signUpButtonBy);
            createAccountButton.Click();
        }
    }
}
