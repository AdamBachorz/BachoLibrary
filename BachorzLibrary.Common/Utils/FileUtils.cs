using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BachorzLibrary.Common.Utils
{
    public static class FileUtils
    {
        public static bool IsFileLocked(string path)
        {
            var fileInfo = new FileInfo(path);
            try
            {
                using (FileStream stream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }
    }
}
