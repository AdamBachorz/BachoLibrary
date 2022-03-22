using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachorzLibrary.Desktop.Extensions
{
    public static class ComboBoxExtensions
    {
        public static IList<D> LoadData<D>(this ComboBox comboBox, IEnumerable<D> data, Func<D, object> propToDisplay)
        {
            comboBox.Items.Clear();
            comboBox.Items.AddRange(data.Select(propToDisplay).ToArray());
            comboBox.SelectedIndex = -1;
            return data.ToList();
        }
    }
}
