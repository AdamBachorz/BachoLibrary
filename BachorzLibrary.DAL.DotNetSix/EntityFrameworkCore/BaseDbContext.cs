using Microsoft.EntityFrameworkCore;

namespace BachorzLibrary.DAL.DotNetSix.EntityFrameworkCore
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext() : base() 
        {
        }

        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }
    }
}
