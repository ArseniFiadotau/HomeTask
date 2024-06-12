namespace Core.Helpers
{
    /// <summary>
    /// Custom attribute for enum elements. It allows enum to have long string descriptions
    /// </summary>
    public class StringValueAttribute : Attribute
    {
        public string Text { get; private set; }

        public StringValueAttribute(string text)
        {
            this.Text = text;
        }
    }
}
