using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WinFormsCatalog.Configuration;

namespace WinFormsCatalog.Data;

public class CatalogDbContextFactory : IDesignTimeDbContextFactory<CatalogDbContext>
{
    public CatalogDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CatalogDbContext>();
        optionsBuilder.UseNpgsql(AppConfiguration.ConnectionString);
        return new CatalogDbContext(optionsBuilder.Options);
    }
}
