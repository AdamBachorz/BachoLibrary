using BachorzLibrary.DesktopHelperApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BachorzLibrary.DesktopHelperApp.OtherForms
{
    public partial class NugetPackerForm : Form
    {
        private readonly string _workingDirectory = @"F:\C#\BachoLibrary\BachoLibrary\BachorzLibrary.Desktop";

        public NugetPackerForm()
        {
            InitializeComponent();
        }

        private void buttonPack_Click(object sender, EventArgs e)
        {
            try
            {
                var version = File.ReadAllText(Codes.CurrentVersionFile);

                var command = Codes.PackCommand + version;
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = @"cmd.exe",
                        Arguments = command,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true,
                        WorkingDirectory = _workingDirectory
                    }
                };

                proc.Start();

                // Change it
                var packageName = Path.Combine(_workingDirectory, $"BachorzLibrary.Desktop.{version}.nupkg");
                var destination = Path.Combine(_workingDirectory, "bin\\Release", Codes.NugetPackagesDirectory, packageName);

                File.Move(packageName, destination);
                IncrementVersion(version);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void IncrementVersion(string currentVersion)
        {
            if (string.IsNullOrWhiteSpace(currentVersion))
            {
                currentVersion = File.ReadAllText(Codes.CurrentVersionFile);
            }
            var match = Regex.Match(currentVersion, @"(?<first>\d+)\.(?<second>\d+)\.(?<last>\d+)");
            var first = Convert.ToInt32(match.Groups["first"].Value);
            var second = Convert.ToInt32(match.Groups["second"].Value);
            var last = Convert.ToInt32(match.Groups["first"].Value);

            last++;
            if (last % 10 == 0)
            {
                second++;
                if (second % 10 == 0)
                {
                    first++;
                }
            }

            var newVersion = $"{first}.{second}.{last}";

            File.WriteAllText(Codes.CurrentVersionFile, newVersion);
        }
    }
}
