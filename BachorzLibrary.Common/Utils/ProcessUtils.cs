using BachorzLibrary.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BachorzLibrary.Common.Utils
{
    public static class ProcessUtils
    {
        public static void ForceOpenDirectory(string directoryPath)
        {
            Process.Start("explorer.exe", directoryPath);
        }

    }
}
