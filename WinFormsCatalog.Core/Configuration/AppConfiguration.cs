using Microsoft.Extensions.Configuration;

namespace WinFormsCatalog.Configuration;

public static class AppConfiguration
{
    private static IConfiguration? _configuration;

    public static IConfiguration Configuration => _configuration ??= BuildConfiguration();

    public static string ConnectionString =>
        Configuration.GetConnectionString("CatalogDb")
        ?? throw new InvalidOperationException("Connection string 'CatalogDb' is not configured.");

    private static IConfiguration BuildConfiguration()
    {
        var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";

        return new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
            .AddEnvironmentVariables()
            .Build();
    }
}
