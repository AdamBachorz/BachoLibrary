using BachorzLibrary.Common.Utils;
using BachorzLibrary.DAL.DotNetSix.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BachorzLibrary.DAL.DotNetSix.Utils
{
    public static class DbContextUtils
    {
        public static void ExplicitConfig(DbContextOptionsBuilder optionsBuilder, string configFile)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (!File.Exists(configFile))
                {
                    throw new FileLoadException("Config file not found", 
                        EnvUtils.GetValueDependingOnEnvironment("DEV", "PROD"));
                }

                var config = JsonConvert.DeserializeObject<EFCCustomConfig>(File.ReadAllText(configFile));
                if (config.IsProduction)
                {
                    optionsBuilder.UseNpgsql(config.ConnectionString);
                }
                else
                {
                    optionsBuilder.UseSqlite(config.ConnectionString);
                }
            }
        }
    }
}
