using Microsoft.EntityFrameworkCore;
using WinFormsCatalog.Data;
using WinFormsCatalog.Services;

namespace WinFormsCatalog.Tests;

public static class IntegrationTestFixture
{
    public const string DefaultConnectionString =
        "Host=localhost;Port=5432;Database=catalog;Username=catalog;Password=catalog";

    public static string ConnectionString =>
        Environment.GetEnvironmentVariable("CATALOG_DB_CONNECTION")
        ?? DefaultConnectionString;

    public static bool IsDatabaseAvailable()
    {
        try
        {
            using var context = CreateContext();
            return context.Database.CanConnect();
        }
        catch
        {
            return false;
        }
    }

    public static CatalogDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<CatalogDbContext>()
            .UseNpgsql(ConnectionString)
            .Options;
        return new CatalogDbContext(options);
    }

    public static CatalogService CreateCatalogService()
    {
        var options = new DbContextOptionsBuilder<CatalogDbContext>()
            .UseNpgsql(ConnectionString)
            .Options;
        var factory = new TestDbContextFactory(options);
        return new CatalogService(factory);
    }

    private sealed class TestDbContextFactory : IDbContextFactory<CatalogDbContext>
    {
        private readonly DbContextOptions<CatalogDbContext> _options;

        public TestDbContextFactory(DbContextOptions<CatalogDbContext> options)
        {
            _options = options;
        }

        public CatalogDbContext CreateDbContext() => new(_options);
    }
}
