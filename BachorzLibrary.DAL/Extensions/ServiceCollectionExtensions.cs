using BachorzLibrary.DAL.NHibernate;
using Microsoft.Extensions.DependencyInjection;

namespace BachorzLibrary.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddNHibernateORM(this IServiceCollection service, IFluentNHibernateCustomConfig fluentNHibernateCustomConfig)
        {
            service.AddSingleton(fluentNHibernateCustomConfig);
            service.AddScoped<INHibernateHelper, NHibernateHelper>();
        }
    }
}
