using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;

namespace Core.Helpers.Controls
{
    public class ComboBox
    {
        public static AppiumDriver<AndroidElement> Driver = AndroidDriver.GetInstance();

        private readonly string xPathLocator;
        private By ComboBoxBy => By.XPath(xPathLocator);
        protected By ComboBoxLabelBy => By.XPath($"{xPathLocator}/android.widget.TextView[@index='1']");
        protected By ComboBoxTextBoxBy => By.XPath($"{xPathLocator}/android.widget.EditText");
        protected string ComboBoxExpandedListViewElementTemplate => xPathLocator + "/following-sibling::android.widget.ListView/android.view.View[@text='{0}']";

        public ComboBox(string xPathStringLocator)
        {
            xPathLocator = xPathStringLocator;
        }

        public void Select(string value)
        {
            var currentValue = Driver.FindElement(ComboBoxLabelBy);
            if (GetValue() != value)
            {
                var dropdownElement = Driver.FindElement(ComboBoxBy);
                dropdownElement.Click();

                WaitHelper.WaitForVisible(ComboBoxTextBoxBy);
                Driver.FindElement(ComboBoxTextBoxBy).SendKeys(value);

                var countryToSelectBy = By.XPath(string.Format(ComboBoxExpandedListViewElementTemplate, value));
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
