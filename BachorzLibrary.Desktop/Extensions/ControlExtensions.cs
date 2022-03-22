using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachorzLibrary.Desktop.Extensions
{
    public static class ControlExtensions
    {
        public static void SetToolTip(this Control control, string text)
        {
            new ToolTip().SetToolTip(control, text);
        }

        public static IEnumerable<C> ExtractControls<C>(this Control control, Func<C, bool> condition = null) where C : Control
        {
            if (control.Controls.Count == 0)
            {
                yield break;
            }

            foreach (C c in control.Controls)
            {
                if (condition == null || condition(c))
                {
                    yield return c;
                }
            }
        }
    }
}
