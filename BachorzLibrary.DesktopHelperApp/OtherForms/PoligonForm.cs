using BachorzLibrary.Desktop.Utils;
using BachorzLibrary.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BachorzLibrary.DesktopHelperApp.Poligon.Documents;

namespace BachorzLibrary.DesktopHelperApp.OtherForms
{
    public partial class PoligonForm : Form
    {
        string _directory;

        public PoligonForm()
        {
            InitializeComponent();
        }

        private void buttonLocate_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var dialogResult = dialog.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    _directory = dialog.SelectedPath;
                }
            }
        }

        private void buttonGenerateDoc_Click(object sender, EventArgs e)
        {
            FormUtils.MessageBoxOperation(sb =>
            {
                if (_directory.HasNotValue())
                {
                    sb.AppendLine("Nie wybrano katalogu docelowego");
                    return;
                }

                var fileInfo = new FileInfo(Path.Combine(_directory, "test.docx"));
                var fileInfoHF = new FileInfo(Path.Combine(_directory, "testHF.docx"));

                var document = new TestDocument(fileInfo, true, false);
                var documentHF = new TestDocumentHeaderFooter(fileInfoHF, true, true);

                document.Save();
                documentHF.Save();

                sb.AppendLine("Wygenerowano");
            },
            false);
        }
    }
}
