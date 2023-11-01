using FluentNHibernate.Cfg;

namespace BachorzLibrary.DAL.DotNetSix.EntityFrameworkCore
{
    public class EFCCustomConfig : IEFCCustomConfig
    {
        public DataBase DataBase { get; set; }
        public bool IsProduction { get; set; }
        public string ConnectionString { get; set; }
        public Dictionary<string, object> ValuesBag { get; set; } = new();
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