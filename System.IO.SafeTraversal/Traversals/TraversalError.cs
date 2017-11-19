namespace System.IO.SafeTraversal
{
    /// <summary>
    /// An error log class.
    /// </summary>
    public class TraversalError
    {
        /// <summary>
        /// Default constructor that accepts error message as a string.
        /// </summary>
        /// <param name="errorMessage">Error message as a string</param>
        public TraversalError(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        /// <summary>
        /// Gets error message.
        /// </summary>
        public string ErrorMessage { get; private set; }
    }
}
