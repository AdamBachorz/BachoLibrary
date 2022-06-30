using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using BachorzLibrary.Web.Config;

namespace BachorzLibrary.Web.Extensions
{
    public static  class ServiceCollectionExtensions
    {
        public static void AddAutoMapperFixture(this IServiceCollection service, MapperConfigurationExpression cfg)
        {
            service.AddSingleton<IMapper>(service => {
                var config = new MapperConfiguration(cfg);
                return new Mapper(config);
            });
        }
    }
}
