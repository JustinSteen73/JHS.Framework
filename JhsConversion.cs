using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JHS.Framework
{


    public static class JhsConversion
    {


        public static t DbNullToDefaultValue<t>(object value)
        {
            if (value.Equals(System.DBNull.Value))
                return default(t);
            else
                return (t)value;
        }

        #region Convert to StronglyTyped function

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Consider using Null Coalescing (?? in C#) instead</remarks>
        public static int NullToZero(object looselyTypedValue)
        {
            int stronglyTypedValue;
            if (looselyTypedValue == null || looselyTypedValue.Equals(DBNull.Value))
                stronglyTypedValue = 0;
            else
                stronglyTypedValue = (int)looselyTypedValue;
            return stronglyTypedValue;
        }

        #endregion


    }


}
