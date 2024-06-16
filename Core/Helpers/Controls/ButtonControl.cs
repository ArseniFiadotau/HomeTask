using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Core.Helpers.Controls
{
    /// <summary>
    /// Custom control for textbox elements.
    /// </summary>
    public class ButtonControl : BaseControl
    {
        private By ButtonBy;

        public ButtonControl(By buttonBy): base(buttonBy) 
        {
            ButtonBy = buttonBy;
        }

        public void Click()
        {
            Console.WriteLine($"\tClick on button '{ButtonBy}'");
            var textBox = Driver.FindElement(ButtonBy);
            textBox.ScrollIntoView();
            textBox.Click();
        }

        public void WaitForDisappear(int? timeoutInSec = null)
            => WaitHelper.WaitForDisappear(ButtonBy, timeoutInSec: timeoutInSec);

        public override void WaitForVisible(int? timeoutInSec = null) 
            => WaitHelper.WaitForVisible(ButtonBy, timeoutInSec: timeoutInSec);
    }
}
