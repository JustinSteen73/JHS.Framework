namespace JHS.Framework
{

    public class JhsException : System.Exception
    {

        #region Constructors

        public JhsException(string message)
            : base(message)
        { }

        /// <summary>
        /// Create a new Exception whose message starts with the specified outerExceptionPrefixMessage and ends with the specified innerException.Message
        /// </summary>        
        public JhsException(string outerExceptionPrefixMessage, System.Exception innerException)
            : base(BuildOuterExceptionMessage(outerExceptionPrefixMessage, innerException), innerException) 
        { }

        #endregion

        public static string BuildOuterExceptionMessage(string outerExceptionPrefixMessage, System.Exception innerException)
        {
            if (outerExceptionPrefixMessage.TrimEnd().EndsWith(":"))
                return outerExceptionPrefixMessage + innerException.Message;
            else
                return outerExceptionPrefixMessage + ": " + innerException.Message;
        }

    }

}
