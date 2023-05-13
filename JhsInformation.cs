using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace JHS.Framework
{


    public static class JhsInformation
    {


        /// <summary>
        /// Returns whether the specified value has the default value of it's type.
        /// </summary>        
        public static bool HasDefaultValue<valueType>(valueType value)
        {
            return value.Equals(default(valueType));
        }

        
        public static bool HasNonDefaultValue<ValueType>(ValueType value)
        {
            return !value.Equals(default(ValueType));
        }


        /// <summary>
        /// Returns whether the specified value is in the specified list.
        /// </summary>
        /// <typeparam name="valueType">The datatype of the specified value and list.</typeparam>
        /// <param name="value">The value to find.</param>
        /// <param name="list">The list to search.</param>
        public static bool InList<valueType>(valueType value, params valueType[] list)
        {
            
            // Attempt to find specified value in specified list
            for (int index = list.GetLowerBound(0); index <= list.GetUpperBound(0); index++)
            {
                if (list[index].Equals(value))
                    // Found value in list
                    return true;
            }

            // value not found in list
            return false;

        }


        /// <summary>
        /// Returns whether the specified value is a database null.
        /// </summary>        
        public static bool IsDbNull(object value)
        {
            return System.DBNull.Value.Equals(value);
        }


    }


}
