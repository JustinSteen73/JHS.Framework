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
        void Insert(string sql);
        int InsertReturnId(string sql);
        int InsertReturnId(string sql, object parameters);
        valueType QueryForValue<valueType>(string sqlQuery);
        arrayValueType QueryForValues<arrayValueType>(string sqlQuery);
        System.Data.DataRow QueryForDataRow(string sqlQuery);
        objectType QueryForObject<objectType>(string sqlQuery) where objectType : new();
        objectType QueryForObject<objectType>(string sqlQuery, object parameters) where objectType : new();
        System.Data.DataTable QueryForDataTable(string sqlQuery);
        void Update(string sql);
    }
}
