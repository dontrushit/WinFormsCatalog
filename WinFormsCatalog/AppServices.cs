using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WinFormsCatalog.Configuration;
using WinFormsCatalog.Data;
using WinFormsCatalog.Services;

namespace WinFormsCatalog;

public static class AppServices
{
    private static ServiceProvider? _provider;

    public static IServiceProvider Provider => _provider ??= Build();

    private static ServiceProvider Build()
    {
        var services = new ServiceCollection();
        services.AddDbContextFactory<CatalogDbContext>(options =>
            options.UseNpgsql(AppConfiguration.ConnectionString));
        services.AddSingleton<ICatalogService, CatalogService>();
        return services.BuildServiceProvider();
    }
}
