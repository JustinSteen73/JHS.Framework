using System;
using System.Collections.Generic;
using System.Text;


namespace JHS.Framework.IO
{

    public class JhsFolderCommands
    {
        
        public static void OpenFolder(string folderPath)
        {
            System.Diagnostics.Process.Start("explorer.exe", folderPath);
        }

    }

}
