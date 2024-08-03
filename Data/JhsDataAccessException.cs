using System;


namespace JHS.Framework.Data
{

    public class JhsDataAccessException : JHS.Framework.JhsException
    {

        #region Constructors

        public JhsDataAccessException(System.Exception innerException, string sql)
            : base($"Error '{innerException.Message}' occurred while executing sql '{sql}'")
        { }

        public JhsDataAccessException(string errMsg, string sql)
            : base($"Error '{errMsg}' occurred while executing sql '{sql}'")
        { }

        #endregion

    }

}
