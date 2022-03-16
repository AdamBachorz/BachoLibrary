using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BachorzLibrary.DAL
{
    public class CustomConfig : ICustomConfig
    {
        public DataBase DataBase { get; set; }
        public bool IsProduction { get; set; }
        public string ConnectionString { get; set; }

        public CustomConfig()
        {

        }

        public CustomConfig(DataBase dataBase, bool isProduction, string connectionString)
        {
            DataBase = dataBase;
            IsProduction = isProduction;
            ConnectionString = connectionString;
        }

        //
    }
}
