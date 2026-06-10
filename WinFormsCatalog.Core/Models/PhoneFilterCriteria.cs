namespace WinFormsCatalog.Models;

public class PhoneFilterCriteria
{
    public IReadOnlyList<string> Producers { get; init; } = [];
    public string? Os { get; init; }
    public decimal PriceMin { get; init; }
    public decimal PriceMax { get; init; } = decimal.MaxValue;
    public bool OnlyInStock { get; init; }
    public int MinRamGb { get; init; }
    public int MinStorageGb { get; init; }
    public string Search { get; init; } = "";
    public PhoneSortOption Sort { get; init; } = PhoneSortOption.PriceAscending;
}
