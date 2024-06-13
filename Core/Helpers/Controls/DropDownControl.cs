using OpenQA.Selenium;
using Tools;

namespace Core.Helpers.Controls
{
    /// <summary>
    /// Custom control for DropDown (Select) controls
    /// </summary>
    public class DropDownControl : BaseControl
    {
        private readonly string xPathBy;
        private By DropDownBy => By.XPath(xPathBy);
        protected By DropDownValueBy => By.XPath($"{xPathBy}//div[contains(@class,'selection ')]");
        protected string DropDownExpandedListViewElementTemplate => xPathBy + "/../..//div[@role='listbox']//div[.='{0}']";

        public DropDownControl(string xPathStringBy): base(By.XPath(xPathStringBy))
        {
            xPathBy = xPathStringBy;
        }

        public void Select(string value)
        {
            if (GetValue() != value)
            {
                var dropdownElement = Driver.FindElement(DropDownBy);
                dropdownElement.ScrollIntoView();
                dropdownElement.Click();

                var itemToSelectBy = By.XPath(string.Format(DropDownExpandedListViewElementTemplate, value));
                WaitHelper.WaitForVisible(itemToSelectBy);
                Driver.FindElement(itemToSelectBy).Click();

                WaitHelper.WaitForDisappear(itemToSelectBy);
                var func = () => GetValue() == value;
                WaitHelper.WaitUntilTrue(func, WaitTime.FiveSec);
            }
            else
            {
                Console.WriteLine($"Value '{value}' is already selected");
            }
        }

        public string GetValue()
        {
            var elements = Driver.FindElements(DropDownValueBy);
            if (elements.Count > 0)
            {
                return elements.First().Text;
            }
            else
            {
                return string.Empty;
            }
        }


        public override void WaitForVisible(int? timeoutInSec = null) => WaitHelper.WaitForVisible(DropDownBy, timeoutInSec: timeoutInSec);
    }
}
