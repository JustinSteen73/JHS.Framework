using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JHS.Framework.Code.TSQL
{
    public static class JhsDynamicSqlConversion
    {

        public static string ToSqlCharLiteral(object value)
        {
            if (value == null)
                return "NULL";
            else if (value == DBNull.Value)
                return "NULL";
            else
            {
                string tsqlCharLiteral = System.Convert.ToString(value);
                tsqlCharLiteral.Replace("'", "''");
                tsqlCharLiteral = "'" + value + "'";
                return tsqlCharLiteral;
            }
        }

        public static string ToSqlNumLiteral(object value) 
        { 
            if (value == null)
                return "NULL";
            else if (value == DBNull.Value)
                return "NULL";
            else
                return System.Convert.ToString(value);
        }

        public static string ToSqlLiteral(object value, System.Data.SqlDbType dataType) 
        {
            switch (dataType) 
            {
                case System.Data.SqlDbType.DateTime:
                case System.Data.SqlDbType.DateTime2:
                case System.Data.SqlDbType.NVarChar:
                case System.Data.SqlDbType.VarChar:                
                    return ToSqlCharLiteral(value);
                default:
                    return ToSqlNumLiteral(value);
            }
        }

    }
}
