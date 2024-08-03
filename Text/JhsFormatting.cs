using System;
using System.Collections.Generic;
using System.Text;

namespace JHS.Framework.Text
{
    public class JhsFormatting
    {

        public static string FormatBytes(long bytes)
        {
            decimal nb;
            string byteText = "";
            if (bytes >= JhsMath.BytesPerTerabyte)
            {
                nb = bytes / (decimal)JhsMath.BytesPerTerabyte;
                byteText = $"{nb:.00} TB";
            }
            else if (bytes >= JhsMath.BytesPerMegabyte)
            {
                nb = bytes / (decimal)JhsMath.BytesPerMegabyte;
                byteText = $"{nb:.00} MB";
            }
            else if (bytes >= JhsMath.BytesPerKilobyte)
            {
                nb = bytes / (decimal)JhsMath.BytesPerKilobyte;
                byteText = $"{nb:.00} KB";
            }
            return byteText;                
        }


    }
}
