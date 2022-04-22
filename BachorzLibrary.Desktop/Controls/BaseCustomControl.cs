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
    public partial class BaseCustomControl : UserControl
    {
        public BaseCustomControl()
        {
            InitializeComponent();
        }

        public void PlaceControl(Form form, int locationX, int locationY)
        {
            Location = new Point(locationX, locationY);
            form.Controls.Add(this);
        }
    }
}
