using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.PageObjects;

namespace Core.Helpers.Controls
{
    public class ComboBox
    {
        public static AppiumDriver<AndroidElement> Driver = AndroidDriver.GetInstance();

        private By ComboBoxBy;
        protected By ComboBoxLabelBy => new ByChained(ComboBoxBy, By.XPath("/android.widget.TextView[@index='1']"));
        protected By ComboBoxTextBoxBy => new ByChained(ComboBoxBy, By.XPath("/android.widget.EditText"));
        protected string ComboBoxExpandedListViewElementTemplate => "/following-sibling::android.widget.ListView/android.view.View[@text='{0}']";

        public ComboBox(By mainlocator)
        {
            ComboBoxBy = mainlocator;
        }

        public void Select(string value)
        {
            var currentValue = Driver.FindElement(ComboBoxLabelBy);
            if (GetValue() != value)
            {
                var dropdownElement = Driver.FindElement(ComboBoxBy);
                dropdownElement.Click();

                WaitHelper.WaitForVisible(ComboBoxTextBoxBy);
                Driver.FindElement(ComboBoxTextBoxBy);

                var countryToSelectBy = By.XPath(string.Format(ComboBoxExpandedListViewElementTemplate, value));
                var comboBoxValueToSelectBy = new ByChained(ComboBoxBy, countryToSelectBy);
                WaitHelper.WaitForVisible(countryToSelectBy);
                Driver.FindElement(countryToSelectBy).Click();

                WaitHelper.WaitForDisappear(countryToSelectBy);
                WaitHelper.WaitForElementTextChange(ComboBoxLabelBy, value);

                Driver.HideKeyboard();
            }
            else
            {
                Console.WriteLine($"Value '{value}' is already selected");
            }
        }

        public string GetValue() => Driver.FindElement(ComboBoxLabelBy).Text;

        public bool IsVisible() => Driver.FindElement(ComboBoxBy).Displayed;
    }
}
