using System.Diagnostics;

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
