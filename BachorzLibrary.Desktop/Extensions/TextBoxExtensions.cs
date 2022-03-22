using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachorzLibrary.Desktop.Extensions
{
    public static class TextBoxExtensions
    {
        public static string TextOrNull(this TextBox textBox)
        {
            return textBox.Enabled ? textBox.Text.Trim() : null;
        }
    }
}
