using AutoMapper;
using BachorzLibrary.Common.Tools.Email;
using Microsoft.Extensions.DependencyInjection;
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

        public static void AddEmailSender(this IServiceCollection services, Action<EmailSenderSettings> settingsInvoker)
        {
            var settings = new EmailSenderSettings();
            settingsInvoker(settings);
            var emailSenderService = new EmailSender(settings);
            services.AddSingleton(emailSenderService);
        }
    }
}
