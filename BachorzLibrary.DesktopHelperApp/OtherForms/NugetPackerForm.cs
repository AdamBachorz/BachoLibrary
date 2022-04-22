using BachorzLibrary.DesktopHelperApp.Classes;
using BachorzLibrary.Common.Extensions;
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
using BachorzLibrary.Common.Utils;

namespace BachorzLibrary.DesktopHelperApp.OtherForms
{
    public partial class NugetPackerForm : Form
    {
        private string _upcomingVersion;
        private readonly string _releasedPackagesDirectory;

        public NugetPackerForm()
        {
            InitializeComponent();
            _releasedPackagesDirectory = Path.Combine(Codes.LibraryDesktopWorkingDirectory, "bin\\Release", Codes.NugetPackagesDirectory);
            GetUpcomingVersionAndUpdateLabel();
        }


        private void buttonPack_Click(object sender, EventArgs e)
        {
            var previousVersion = new string(_upcomingVersion);
            try
            {
                var command = Codes.PackCommand + _upcomingVersion;
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = @"cmd.exe",
                        Arguments = command,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true, 
                        WorkingDirectory = _releasedPackagesDirectory
                    },
                };

                IncrementVersion(saveToFile: true);
                GetUpcomingVersionAndUpdateLabel();
                proc.Start();
                
            }
            catch (Exception ex)
            {
                if (_upcomingVersion != previousVersion)
                {
                    File.WriteAllText(Codes.UpcomingVersionFile, previousVersion);
                    _upcomingVersion = previousVersion;
                    labelUpcomingVersion.Text = _upcomingVersion;
                }
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonOpenPackagesDirectory_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", _releasedPackagesDirectory);
        }

        private void GetUpcomingVersionAndUpdateLabel()
        {
            _upcomingVersion = File.ReadAllText(Codes.UpcomingVersionFile);
            labelUpcomingVersion.Text = _upcomingVersion;
        }

        private string IncrementVersion(bool saveToFile)
        {
            if (_upcomingVersion.HasNotValue())
            {
                _upcomingVersion = File.ReadAllText(Codes.UpcomingVersionFile);
            }

            var match = Regex.Match(_upcomingVersion, @"(?<first>\d+)\.(?<second>\d+)\.(?<last>\d+)");
            var first = match.GroupOrEmpty("first").ToInt();
            var second = match.GroupOrEmpty("second").ToInt();
            var last = match.GroupOrEmpty("last").ToInt();

            last++;
            if (last % 100 == 0)
            {
                last = 0;
                second++;
                if (second % 10 == 0)
                {
                    second = 0;
                    first++;
                }
            }

            var newVersion = $"{first}.{second}.{last}";

            if (saveToFile)
            {
                File.WriteAllText(Codes.UpcomingVersionFile, newVersion); 
            }

            return newVersion;
        }

    }
}
