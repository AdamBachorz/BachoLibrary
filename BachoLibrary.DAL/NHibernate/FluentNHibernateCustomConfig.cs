using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace BachoLibrary.DAL.NHibernate
{
    public class FluentNHibernateCustomConfig : IFluentNHibernateCustomConfig
    {
        public DataBase DataBase { get; set; }
        public bool IsProduction { get; set; }
        public string ConnectionString { get; set; }
        public Action<MappingConfiguration> Mapping { get; set; }

        public FluentNHibernateCustomConfig()
        {

        }
        public FluentNHibernateCustomConfig(ICustomConfig customConfig)
        {
            DataBase = customConfig.DataBase;
            IsProduction = customConfig.IsProduction;
            ConnectionString = customConfig.ConnectionString;
        }
        public FluentNHibernateCustomConfig(DataBase dataBase, bool isProduction, string connectionString)
        {
            DataBase = dataBase;
            IsProduction = isProduction;
            ConnectionString = connectionString;
        }

        public FluentConfiguration BuildNHibernateConfigurationForDataBase()
        {
            return Fluently.Configure()
                .Database(BuildPersistenceConfigurer(DataBase))
                .Mappings(Mapping);
        }

        private IPersistenceConfigurer BuildPersistenceConfigurer(DataBase dataBase)
        {
            return dataBase switch
            {
                DataBase.MSSQL => throw new NotImplementedException(),
                DataBase.PostgreSQL => PostgreSQLConfiguration.Standard.ConnectionString(ConnectionString),
                DataBase.MySQL => throw new NotImplementedException(),
                _ => throw new NotImplementedException(),
            };
        }

    }
}