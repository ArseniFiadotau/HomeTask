using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using Tools;
using System.Transactions;
using Core.Helpers;

namespace Core.Pages.AvaTrade.Registration
{
    public class ATInitialSignUpPage : BasePage
    {
        protected By SignUpForFreeBy => By.XPath("//android.widget.TextView[@text='Sign-Up for Free!']");
        string locator = "//android.view.View[./android.view.View[@text='Country of Residence']]";
        protected By CountryDropDownBy => By.XPath(locator);
        protected By CountryLabelBy => By.XPath($"{locator}/android.widget.TextView[@index='1']");
        protected By CountryTextBox => By.XPath($"{locator}/android.widget.EditText");
        protected string CountryExpandedListViewElementTemplate => locator + "/following-sibling::android.widget.ListView/android.view.View[@text='{0}']";


        protected By EmailTextBoxBy => By.XPath("//android.view.View[./android.view.View[@text='Email']]/android.widget.EditText");
        protected By PasswordTextBoxBy => By.XPath("//android.view.View[./android.view.View[@text='Password']]/android.widget.EditText");
        protected By CreateMyAccountButtonBy => By.XPath("//android.widget.Button[@text='Create My Account']");

        public override void WaitForPageLoading()
        {
            WaitForVisible(SignUpForFreeBy, WaitTime.OneMin);
            WaitForVisible(CreateMyAccountButtonBy, WaitTime.OneMin);
        }

        public bool IsCountryDropdownVisible()
        {
            var dropdownElement = Driver.FindElement(CountryDropDownBy);
            return dropdownElement.Displayed;
        }

        public void SelectCountry(string country)
        {
            var currentCountry = Driver.FindElement(CountryLabelBy);
            if (currentCountry.Text != country)
            {
                var dropdownElement = Driver.FindElement(CountryDropDownBy);
                dropdownElement.Click();

                WaitForVisible(CountryTextBox);
                SendKeysToElementBy(CountryTextBox, country);
                ;
                var countryToSelectBy = By.XPath(string.Format(CountryExpandedListViewElementTemplate, country));
                WaitForVisible(countryToSelectBy);
                Driver.FindElement(countryToSelectBy).Click();

                WaitForDisappear(countryToSelectBy);

                currentCountry = Driver.FindElement(CountryLabelBy);
                WaitHelper.WaitForElementTextChange(currentCountry, country);

                Driver.HideKeyboard();
            }
            else
            {
                Console.WriteLine($"Country '{country}' is already selected");
            }
        }

        public void FulfillInitialInformation(string country, string email, string password)
        {
            SelectCountry(country);

            SendKeysToElementBy(EmailTextBoxBy, email);

            SendKeysToElementBy(PasswordTextBoxBy, password);

            var button = Driver.FindElement(CreateMyAccountButtonBy);
            button.Click();
            button.WaitForDisappear();
        }
    }
}
