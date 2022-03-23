using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachorzLibrary.Desktop.Config
{
    public interface ISimpleInjectorConfig
    {
        Action<Container> MainForm { get; set; }
        Action<Container> RegisteredModules { get; set; }
        bool IsSaved { get; }
        void SaveConfig();
        F MainFormInstance<F>() where F : Form;
    }
}
