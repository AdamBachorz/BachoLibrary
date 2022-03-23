using BachorzLibrary.Desktop.Config;
using BachorzLibrary.DesktopHelperApp.Classes.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BachorzLibrary.DesktopHelperApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 

        private static ISimpleInjectorConfig _simpleInjectorConfig;

        [STAThread]
        static void Main()
        {
            _simpleInjectorConfig = new SimpleInjectorConfig()
            {
                MainForm = container => container.Register<MainForm>(),
                RegisteredModules = container => DependencyInjection.RegisterModules(container),
            };
            _simpleInjectorConfig.SaveConfig();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(_simpleInjectorConfig.MainFormInstance<MainForm>());
        }
    }
}
