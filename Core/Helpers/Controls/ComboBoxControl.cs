using OpenQA.Selenium;

namespace Core.Helpers.Controls
{
    public class ComboBoxControl: BaseControl
    {
        private readonly string xPathLocator;
        private By ComboBoxBy => By.XPath(xPathLocator);
        protected By ComboBoxLabelBy => By.XPath($"{xPathLocator}/android.widget.TextView[@index='1']");
        protected By ComboBoxTextBoxBy => By.XPath($"{xPathLocator}/android.widget.EditText");
        protected string ComboBoxExpandedListViewElementTemplate => xPathLocator + "/following-sibling::android.widget.ListView/android.view.View[@text='{0}']";

        public ComboBoxControl(string xPathStringLocator): base(By.XPath(xPathStringLocator))
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
                Driver.HideKeyboardIfShown();

                WaitHelper.WaitForVisible(ComboBoxTextBoxBy);
                Driver.FindElement(ComboBoxTextBoxBy).SendKeys(value);

                var countryToSelectBy = By.XPath(string.Format(ComboBoxExpandedListViewElementTemplate, value));
                WaitHelper.WaitForVisible(countryToSelectBy);
                Driver.FindElement(countryToSelectBy).Click();

                WaitHelper.WaitForDisappear(countryToSelectBy);
                WaitHelper.WaitForElementTextChange(ComboBoxLabelBy, value);

                Driver.HideKeyboardIfShown();
            }
            else
            {
                Console.WriteLine($"Value '{value}' is already selected");
            }
        }

        public string GetValue() => Driver.FindElement(ComboBoxLabelBy).Text;

        public override void WaitForVisible(int? timeoutInSec = null) => WaitHelper.WaitForVisible(ComboBoxBy, timeoutInSec: timeoutInSec);
    }
}
