using OpenQA.Selenium;

namespace Core.Helpers.Controls
{
    /// <summary>
    /// Custom control for DropDown (Select) controls
    /// </summary>
    public class DropDownControl : BaseControl
    {
        private readonly string xPathBy;
        private By DropDownBy => By.XPath(xPathBy);
        protected By DropDownValueBy => By.XPath($"{xPathBy}//android.widget.Button");
        protected string DropDownExpandedListViewElementTemplate => xPathBy + "//android.widget.ListView/android.view.View[@text='{0}']";

        public DropDownControl(string xPathStringBy): base(By.XPath(xPathStringBy))
        {
            xPathBy = xPathStringBy;
        }

        public void Select(string value)
        {
            if (GetValue() != value)
            {
                var dropdownElement = Driver.FindElement(DropDownBy);
                dropdownElement.Click();

                var itemToSelectBy = By.XPath(string.Format(DropDownExpandedListViewElementTemplate, value));
                WaitHelper.WaitForVisible(itemToSelectBy);
                Driver.FindElement(itemToSelectBy).Click();

                WaitHelper.WaitForDisappear(itemToSelectBy);
                WaitHelper.WaitForElementTextChange(DropDownValueBy, value);
            }
            else
            {
                Console.WriteLine($"Value '{value}' is already selected");
            }
        }

        public string GetValue() => Driver.FindElement(DropDownValueBy).Text;

        public override void WaitForVisible(int? timeoutInSec = null) => WaitHelper.WaitForVisible(DropDownBy, timeoutInSec: timeoutInSec);
    }
}
