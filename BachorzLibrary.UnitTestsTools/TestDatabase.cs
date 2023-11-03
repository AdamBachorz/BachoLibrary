using BachorzLibrary.DAL.DotNetSix.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BachorzLibrary.UnitTestsTools;

public static class TestDatabase
{
    public static void Reset<DbC>() where DbC : BaseDbContext
    {
        CreateContext<DbC>().Database.EnsureDeleted();
    }

    public static DbC CreateContext<DbC>(bool allowLazyLoading = false) where DbC : BaseDbContext
    {
        var services = new ServiceCollection();
        services.AddTestDatabaseContext<DbC>();
        services.AddLogging();
        var sp = services.BuildServiceProvider();
        var context = sp.GetRequiredService<DbC>();

        context.ChangeTracker.LazyLoadingEnabled = allowLazyLoading;

        return context;
    }

    public static DbC GetTestContext<DbC>(this IFixture fixture) where DbC : BaseDbContext 
    { 
        return CreateContext<DbC>(true); 
    }

    public static void AddTestDatabaseContext<DbC>(this IFixture fixture, bool allowLazyLoading = false) where DbC : BaseDbContext
    {
        Reset<DbC>();
        fixture.Register(() => CreateContext<DbC>(allowLazyLoading));
    }

    public static IServiceCollection AddTestDatabaseContext<DbC>(this IServiceCollection services) where DbC : BaseDbContext
    {
        services.AddDbContext<DbC>(builder =>
        {
            builder.UseInMemoryDatabase("Dummy");
        });

        return services;
    }
}
