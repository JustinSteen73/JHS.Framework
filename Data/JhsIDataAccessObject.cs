using System;
using System.Collections.Generic;
using System.Text;

namespace JHS.Framework.Data
{
    public interface JhsIDataAccessObject
    {
        // Properties
        string ConnectionString { get; }
        // Methods
        valueType QueryForValue<valueType>(string sqlQuery);
        arrayValueType QueryForValues<arrayValueType>(string sqlQuery);

    }
}
