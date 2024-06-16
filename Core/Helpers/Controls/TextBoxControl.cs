using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Core.Helpers.Controls
{
    /// <summary>
    /// Custom control for textbox elements.
    /// </summary>
    public class TextBoxControl: BaseControl
    {
        private By TextBoxBy;

        public TextBoxControl(By textBoxBy): base(textBoxBy) 
        {
            TextBoxBy = textBoxBy;
        }

        public void ClickAndSendKeys(string value)
        {
            Console.WriteLine($"\tClick on textbox '{TextBoxBy}' and send text '{value}'");
            var textBox = Driver.FindElement(TextBoxBy);
            textBox.ScrollIntoView();
            if (textBox.Text != value)
            {
                textBox.Click();
                textBox.SendKeys(value);
            }
            else
            {
                Console.WriteLine($"\tValue '{value}' is already in textbox");
            }
        }

        public void SendKeys(string value)
        {
            Console.WriteLine($"\tSend text '{value}' into textbox '{TextBoxBy}'");
            var textBox = Driver.FindElement(TextBoxBy);
            if (textBox.Text != value)
            {
                textBox.SendKeys(value);
                
                //wait a bit before next operation
                Thread.Sleep(300);
            }
            else
            {
                Console.WriteLine($"\tValue '{value}' is already in textbox");
            }
        }

        public void SendKeysWithActions(string value)
        {
            var textBox = Driver.FindElement(TextBoxBy);
            if (textBox.Text != value)
            {
                new Actions(Driver).MoveToElement(textBox).Click().SendKeys(value).Build().Perform();
            }
            else
            {
                Console.WriteLine($"\tValue '{value}' is already in textbox");
            }            
        }

        public void Clear()
        {
            var textBox = Driver.FindElement(TextBoxBy);
            textBox.Clear();
        }

        public override void WaitForVisible(int? timeoutInSec = null) 
            => WaitHelper.WaitForVisible(TextBoxBy, timeoutInSec: timeoutInSec);
    }
}
