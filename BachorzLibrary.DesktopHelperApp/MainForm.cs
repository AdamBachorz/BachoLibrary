using BachorzLibrary.DesktopHelperApp.OtherForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachorzLibrary.DesktopHelperApp
{
    public partial class MainForm : Form
    {
        private NugetPackerForm _nugetPackerForm;
        public MainForm(NugetPackerForm nugetPackerForm)
        {
            InitializeComponent();
            _nugetPackerForm = nugetPackerForm;
        }

        private void buttonNugetPacker_Click(object sender, EventArgs e)
        {
            _nugetPackerForm.ShowDialog();
        }
    }
}
