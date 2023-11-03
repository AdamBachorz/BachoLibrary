using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using BachorzLibrary.DAL.NHibernate;
using BachorzLibrary.Common.Tools.Email;
using BachorzLibrary.DAL;
using System;

namespace BachorzLibrary.Common.Extensions
{
    public static  class ServiceCollectionExtensions
    {
        public static void AddObjectMappingConfiguration(this IServiceCollection service, MapperConfigurationExpression cfg)
        {
            service.AddSingleton<IMapper>(service => {
                var config = new MapperConfiguration(cfg);
                return new Mapper(config);
            });
        }

        public static void AddNHibernateORM(this IServiceCollection service, IFluentNHibernateCustomConfig fluentNHibernateCustomConfig)
        {
            service.AddSingleton(fluentNHibernateCustomConfig);
            service.AddScoped<INHibernateHelper, NHibernateHelper>();
        }

        public static void AddEmailSenderService(this IServiceCollection services, ICustomConfig config, Action<EmailSenderSettings> settingsInvoker)
        {
            var senderValues = config.ValuesBag["Sender"] as string;
            var settings = new EmailSenderSettings();
            settingsInvoker(settings);
            settings.SenderValues = senderValues;
            var emailSenderService = new EmailSender(settings);

            services.AddSingleton(emailSenderService);
        }
    }
}
