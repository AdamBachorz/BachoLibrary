using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System;
using System.Collections.Generic;
using System.Text;

namespace BachorzLibrary.DAL.DotNetSix.EntityFrameworkCore
{
    public class EFCCustomConfig : IEFCCustomConfig
    {
        public DataBase DataBase { get; set; }
        public bool IsProduction { get; set; }
        public string ConnectionString { get; set; }
        public Action<MappingConfiguration> Mapping { get; set; }

        public EFCCustomConfig()
        {

        }
        public EFCCustomConfig(ICustomConfig customConfig)
        {
            DataBase = customConfig.DataBase;
            IsProduction = customConfig.IsProduction;
            ConnectionString = customConfig.ConnectionString;
        }
        public EFCCustomConfig(DataBase dataBase, bool isProduction, string connectionString)
        {
            DataBase = dataBase;
            IsProduction = isProduction;
            ConnectionString = connectionString;
        }

    }
}