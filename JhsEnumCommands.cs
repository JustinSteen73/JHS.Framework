using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHS.Framework
{

    public static class JhsEnumCommands
    {

        public static enumType ToEnum<enumType>(string enumName)
        {
            try
            {
                enumType e = (enumType)System.Enum.Parse(typeof(enumType), enumName);
                return e;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception($"Error converting '{enumName}' to {typeof(enumType).ToString()}: {ex.Message}");
            }
        }

        public static enumType ToEnum<enumType>(string enumName, bool ignoreCase)
        {
            try
            {
                enumType e = (enumType)System.Enum.Parse(typeof(enumType), enumName, ignoreCase);
                return e;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception($"Error converting '{enumName}' to {typeof(enumType).ToString()}: {ex.Message}");
            }
        }

    }   //end class

}
