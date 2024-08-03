using System;
using System.Collections.Generic;
using System.Data;                      // Required for DataTable, DataColumn
using System.Text;


namespace JHS.Framework.Data
{

    public static class JhsDataCommands
    {


        public static string DataToString(DataTable data, short maxColWidth)
        {
            return "";
        }


        public static string DataToHtml(DataTable data)
        {

            System.Text.StringBuilder html = new System.Text.StringBuilder();
            
            html.AppendLine("<table style='padding:10px'>");

            // Generate column headers
            html.AppendLine("<tr>");
            foreach (DataColumn col in data.Columns)
            {
                html.AppendLine($@"<th>{col.ColumnName}</th>");
            }
            html.AppendLine(@"</tr>");

            // Generate rows
            foreach (DataRow row in data.Rows)
            {
                html.AppendLine("<tr>");
                for (int colIndex = 0; colIndex < data.Columns.Count; colIndex++)
                {
                    html.AppendLine($@"<td>{row[colIndex]}</td>");
                }
                html.AppendLine(@"</tr>");
            }

            html.AppendLine(@"</table>");

            return html.ToString();

        }


    }

}
