using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachorzLibrary.Desktop.Controls
{
    public partial class EditableLabel : BaseCustomControl
    {
        public bool EditMode { get; set; }
        public string LabelText
        {
            get => label.Text;
            set => label.Text = value;
        }
        public bool Border
        {
            set => panel.BorderStyle = value ? BorderStyle.FixedSingle : BorderStyle.None;
        }

        public Action<string> OnChangesApplied { get; set; }

        public EditableLabel()
        {
            InitializeComponent();
        }

        public EditableLabel(bool border = false) : this()
        {
            Border = border;
        }

        private void ApplyChanges()
        {
            var newText = textBox.Text;
            label.Text = newText;
            textBox.Visible = false;
            label.Visible = true;

            if (OnChangesApplied != null)
            {
                OnChangesApplied(newText);
            }

            EditMode = false;
        }

        private void CancelEdit()
        {
            label.Text = textBox.Text;
            textBox.Visible = false;
            label.Visible = true;
            EditMode = false;
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ApplyChanges();
                    break;
                case Keys.Escape:
                    CancelEdit();
                    break;
                default:
                    break;
            }
        }

        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                EditMode = true;
                textBox.Text = label.Text;
                label.Visible = false;
                textBox.Visible = true;
            }
        }
    }
}
