using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MiniFileList
{
    class Logic
    {
        public static bool ValidateDirectory(string dir)
        {
            if (string.IsNullOrEmpty(dir))
            {
                return false;
            }

            DirectoryInfo dirInfo = null;
            try
            {
                dirInfo = new DirectoryInfo(dir);
            }
            catch
            {
                return false;
            }

            if (!dirInfo.Exists)
            {
                return false;
            }

            return true;
        }

        public static bool ValidateFile(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }

            FileInfo fileInfo = null;
            try
            {
                fileInfo = new FileInfo(path);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
