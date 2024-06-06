using OpenQA.Selenium;

namespace Core.Helpers.Controls
{
    public class TextBoxControl: BaseControl
    {
        private By TextBoxBy;

        public TextBoxControl(By textBoxBy)
        {
            TextBoxBy = textBoxBy;
        }

        public void EnterValue(string value)
        {
            var textBox = Driver.FindElement(TextBoxBy);
            if (textBox.Text != value)
            {
                textBox.Click();
                textBox.SendKeys(value);

                Driver.HideKeyboardIfShown();
            }
            else
            {
                Console.WriteLine($"Value '{value}' is already in textbox");
            }
        }

        public override void WaitForVisible() => WaitHelper.WaitForVisible(TextBoxBy);
    }
}
