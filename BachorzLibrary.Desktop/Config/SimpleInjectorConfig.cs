using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachorzLibrary.Desktop.Config
{
    public class SimpleInjectorConfig : ISimpleInjectorConfig
    {
        public Action<Container> MainForm { get; set; }
        public Action<Container> RegisteredModules { get; set; }

        private Container _container;
        private bool _isSaved;

        public SimpleInjectorConfig()
        {
            _container = new Container();
            _container.Options.EnableAutoVerification = false;

        }

        public void SaveConfig()
        {
            try
            {
                MainForm(_container);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("MainForm is not registered");
            }

            try
            {
                RegisteredModules(_container);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Modules are not registered");
            }

            _isSaved = true;
        }

        public F MainFormInstance<F>() where F : Form
        {
            if (!_isSaved)
            {
                throw new Exception("You have to save your configuration save. Use SaveConfig() method");
            }

            return _container.GetInstance<F>();
        }

        public bool IsSaved => _isSaved;
    }
}
