using BachorzLibrary.DesktopHelperApp.OtherForms;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BachorzLibrary.DesktopHelperApp.Classes.Config
{
    public static class DependencyInjection
    {
        public static void RegisterModules(Container container)
        {
            // Forms
            container.Register<NugetPackerForm>();
        }
    }
}
