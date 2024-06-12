using OpenQA.Selenium;

namespace Core.Helpers.Controls
{
    /// <summary>
    /// Custom control for ComboBox (Select with ability to type value into it) controls
    /// </summary>
    public class ComboBoxControl: BaseControl
    {
        private readonly string xPathLocator;
        private By ComboBoxBy => By.XPath(xPathLocator);
        protected By ComboBoxValueBy => By.XPath($"{xPathLocator}/android.widget.TextView[@index='1']");
        protected By ComboBoxTextBoxBy => By.XPath($"{xPathLocator}/android.widget.EditText");
        protected string ComboBoxExpandedListViewElementTemplate => xPathLocator + "/following-sibling::android.widget.ListView/android.view.View[@text='{0}']";

        public ComboBoxControl(string xPathStringLocator): base(By.XPath(xPathStringLocator))
        {
            xPathLocator = xPathStringLocator;
        }

        public void Select(string value)
        {
            if (GetValue() != value)
            {
                var dropdownElement = Driver.FindElement(ComboBoxBy);
                dropdownElement.Click();
                Driver.HideKeyboardIfShown();

                WaitHelper.WaitForVisible(ComboBoxTextBoxBy);
                Driver.FindElement(ComboBoxTextBoxBy).SendKeys(value);

                var itemToSelectBy = By.XPath(string.Format(ComboBoxExpandedListViewElementTemplate, value));
                WaitHelper.WaitForVisible(itemToSelectBy);
                Driver.FindElement(itemToSelectBy).Click();

                WaitHelper.WaitForDisappear(itemToSelectBy);
                WaitForValueToBe(value);

                Driver.HideKeyboardIfShown();
            }
            else
            {
                Console.WriteLine($"Value '{value}' is already selected");
            }
        }

        public string GetValue() => Driver.FindElement(ComboBoxValueBy).Text;

        public void WaitForValueToBe(string value)
        {
            WaitHelper.WaitForElementTextChange(ComboBoxValueBy, value);
        }

        public override void WaitForVisible(int? timeoutInSec = null) => WaitHelper.WaitForVisible(ComboBoxBy, timeoutInSec: timeoutInSec);
    }
}
