using BachorzLibrary.DAL;
using BachorzLibrary.DAL.NHibernate;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BachorzLibrary.Web.Config
{
    public class DependencyInjectionHelper
    {
        public static void RegisterBasics<C>(IServiceCollection services, Func<IServiceProvider, C> customConfig)
        {
            // TBE
            //services.AddSingleton<C>(customConfig);
            services.AddScoped<INHibernateHelper, NHibernateHelper>();
        }
    }
}
