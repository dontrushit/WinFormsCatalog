namespace WinFormsCatalog.Models;

public class CatalogFilterOptions
{
    public IReadOnlyList<string> Producers { get; init; } = [];
    public IReadOnlyList<string> OperatingSystems { get; init; } = [];
    public decimal MaxPrice { get; init; }
    public int MaxRamGb { get; init; }
    public int MaxStorageGb { get; init; }
}
