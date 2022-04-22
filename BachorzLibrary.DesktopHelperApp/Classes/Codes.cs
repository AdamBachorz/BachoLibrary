using System;
using System.Collections.Generic;
using System.Text;

namespace BachorzLibrary.DesktopHelperApp.Classes
{
    public static class Codes
    {
        public const string PackCommand = "/c nuget pack ..\\..\\..\\BachorzLibrary.Desktop.csproj -Version ";
        public const string UpcomingVersionFile = "Files\\UpcomingVersion.txt";
        public const string NugetPackagesDirectory = "NugetPackages";
        public const string LibraryDesktopWorkingDirectory = @"F:\C#\BachoLibrary\BachoLibrary\BachorzLibrary.Desktop";
        public const string DesktopHelperAppWorkingDirectory = @"F:\C#\BachoLibrary\BachoLibrary\BachorzLibrary.DesktopHelperApp";
    }
}
