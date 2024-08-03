using System;
using System.Text;


namespace JHS.Framework.IO
{

    public class JhsFileCommands
    {

        public static string GetFileName(string FilePath)
        {
            return System.IO.Path.GetFileName(FilePath);
        }

        public static string GetFileExtension(string FilePath)
        {
            return System.IO.Path.GetExtension(FilePath);
        }

    }

}
