using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachorzLibrary.Desktop.Extensions
{
    public static class LabelExtensions
    {
        public static string SetBoundaryText(this Label label, int value, int boundaryValue, bool setToolTip = true)
        {
            label.Text = value > boundaryValue ? $"{boundaryValue}+" : value.ToString();

            if (setToolTip && value > boundaryValue)
            {
                label.SetToolTip(value.ToString());
            }

            return label.Text;
        }
    }
}
