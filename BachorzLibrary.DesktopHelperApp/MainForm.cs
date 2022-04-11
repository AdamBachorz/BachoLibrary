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
        private PoligonForm _poligonForm;
        public MainForm(NugetPackerForm nugetPackerForm, PoligonForm poligonForm)
        {
            InitializeComponent();
            _nugetPackerForm = nugetPackerForm;
            _poligonForm = poligonForm;
        }

        private void buttonNugetPacker_Click(object sender, EventArgs e)
        {
            _nugetPackerForm.ShowDialog();
        }

        private void buttonPoligon_Click(object sender, EventArgs e)
        {
            _poligonForm.ShowDialog();
        }
    }
}
