namespace Core.Helpers
{
    /// <summary>
    /// Custom exception that is used in custom waiting operations
    /// </summary>
    public class WaitException : Exception
    {
        public WaitException()
        {
        }

        public WaitException(string message)
            : base(message)
        {
        }

        public WaitException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
