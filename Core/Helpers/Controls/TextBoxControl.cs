using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;

namespace Core.Helpers.Controls
{
    public class TextBoxControl: BaseControl
    {
        private By TextBoxBy;

        public TextBoxControl(By textBoxBy): base(textBoxBy) 
        {
            TextBoxBy = textBoxBy;
        }

        public void ClickAndSendKeys(string value)
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

        public void SendKeys(string value)
        {
            var textBox = Driver.FindElement(TextBoxBy);
            if (textBox.Text != value)
            {
                textBox.SendKeys(value);
                Driver.HideKeyboardIfShown();
            }
            else
            {
                Console.WriteLine($"Value '{value}' is already in textbox");
            }
        }

        public void SendKeysWithActions(string value)
        {
            var textBox = Driver.FindElement(TextBoxBy);
            if (textBox.Text != value)
            {
                new Actions(Driver).MoveToElement(textBox).SendKeys(value).Build().Perform();
                Driver.HideKeyboardIfShown();
            }
            else
            {
                Console.WriteLine($"Value '{value}' is already in textbox");
            }            
        }

        public void Clear()
        {
            var textBox = Driver.FindElement(TextBoxBy);
            textBox.Clear();
        }

        public override void WaitForVisible(int? timeoutInSec = null) => WaitHelper.WaitForVisible(TextBoxBy, timeoutInSec: timeoutInSec);
    }
}
