using BachoLibrary.DAL;
using BachoLibrary.DAL.NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BachoLibrary.DAL.NHibernate
{
    public class NHibernateHelper : INHibernateHelper
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly FluentConfiguration _configuration;
        private readonly IFluentNHibernateCustomConfig _customConfig;

        public NHibernateHelper(IFluentNHibernateCustomConfig customConfig)
        {
            _customConfig = customConfig;
            _configuration = _customConfig.BuildNHibernateConfigurationForDataBase();
            _sessionFactory = _configuration.BuildSessionFactory();
        }

        private void Mapping(MappingConfiguration mapping)
        {
            // Make it universal
            //mapping.FluentMappings.Add<UserMapping>().Conventions.Add<FluentNHibernateEnumConvention>();
            //mapping.FluentMappings.Add<SpendingGroupMapping>();
            //mapping.FluentMappings.Add<UserSpendingGroupMapping>();
            //mapping.FluentMappings.Add<ConstantSpendingMapping>();
            //mapping.FluentMappings.Add<SpendingMapping>();
            //mapping.FluentMappings.Add<MonthlySpendingMapping>();
        }

        private HbmMapping BasicMapping()
        {
            var modelMapper = new ModelMapper();

            modelMapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());

            var mapping = modelMapper.CompileMappingForAllExplicitlyAddedEntities();

            return mapping;
        }

        private static void BuildSchema(Configuration config)
        {
            // This NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it.
            var dbSchemaExport = new SchemaExport(config);
            
            dbSchemaExport.SetOutputFile("db_creation.sql");
            dbSchemaExport.Drop(true, true);
            dbSchemaExport.Create(false, true);
        }

        public ISession OpenSession() => _sessionFactory.OpenSession();

        public IFluentNHibernateCustomConfig CustomConfig => _customConfig;
    }
}
