using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WinFormsCatalog.Configuration;
using WinFormsCatalog.Data;
using WinFormsCatalog.Services;

namespace WinFormsCatalog;

public static class CompositionRoot
{
    private static ServiceProvider? _serviceProvider;

    public static IServiceProvider Services => _serviceProvider ??= BuildServiceProvider();

    private static ServiceProvider BuildServiceProvider()
    {
        var services = new ServiceCollection();
        services.AddDbContextFactory<CatalogDbContext>(options =>
            options.UseNpgsql(AppConfiguration.ConnectionString));
        services.AddSingleton<ICatalogService, CatalogService>();
        return services.BuildServiceProvider();
    }
}
