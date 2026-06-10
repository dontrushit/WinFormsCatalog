using System.Reflection;

namespace WinFormsCatalog.Data.Seed;

public static class CatalogSeed
{
    public static string GetSql()
    {
        var assembly = typeof(CatalogSeed).Assembly;
        const string resourceName = "WinFormsCatalog.Data.Seed.catalog_seed.sql";

        using var stream = assembly.GetManifestResourceStream(resourceName)
            ?? throw new InvalidOperationException($"Embedded resource '{resourceName}' was not found.");

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}
