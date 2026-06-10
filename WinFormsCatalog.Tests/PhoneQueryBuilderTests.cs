using WinFormsCatalog.Models;
using WinFormsCatalog.Services;

namespace WinFormsCatalog.Tests;

public class PhoneQueryBuilderTests
{
    private static readonly Phone[] SamplePhones =
    [
        new()
        {
            Id = 1,
            Name = "Xiaomi Redmi Note 15 Pro",
            Producer = "Xiaomi",
            Os = "Android",
            Price = 1150m,
            RamGb = 8,
            StorageGb = 256,
            InStock = true
        },
        new()
        {
            Id = 2,
            Name = "Apple iPhone 15",
            Producer = "Iphone",
            Os = "IOS",
            Price = 1500m,
            RamGb = 6,
            StorageGb = 128,
            InStock = false
        },
        new()
        {
            Id = 3,
            Name = "Samsung Galaxy A55",
            Producer = "Samsung",
            Os = "Android",
            Price = 1100m,
            RamGb = 8,
            StorageGb = 128,
            InStock = true
        }
    ];

    [Fact]
    public void ApplyFilters_FiltersByProducer()
    {
        var result = PhoneQueryBuilder
            .ApplyFilters(SamplePhones.AsQueryable(), new PhoneFilterCriteria
            {
                Producers = ["Xiaomi"]
            })
            .ToList();

        Assert.Single(result);
        Assert.Equal("Xiaomi", result[0].Producer);
    }

    [Fact]
    public void ApplyFilters_FiltersByPriceRange()
    {
        var result = PhoneQueryBuilder
            .ApplyFilters(SamplePhones.AsQueryable(), new PhoneFilterCriteria
            {
                PriceMin = 1100m,
                PriceMax = 1200m
            })
            .ToList();

        Assert.Equal(2, result.Count);
        Assert.All(result, phone => Assert.InRange(phone.Price, 1100m, 1200m));
    }

    [Fact]
    public void ApplyFilters_FiltersOnlyInStock()
    {
        var result = PhoneQueryBuilder
            .ApplyFilters(SamplePhones.AsQueryable(), new PhoneFilterCriteria
            {
                OnlyInStock = true
            })
            .ToList();

        Assert.Equal(2, result.Count);
        Assert.All(result, phone => Assert.True(phone.InStock));
    }

    [Fact]
    public void ApplyFilters_FiltersBySearchCaseInsensitive()
    {
        var result = PhoneQueryBuilder
            .ApplyFilters(SamplePhones.AsQueryable(), new PhoneFilterCriteria
            {
                Search = "iphone"
            })
            .ToList();

        Assert.Single(result);
        Assert.Contains("iPhone", result[0].Name, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void ApplySort_SortsByPriceDescending()
    {
        var result = PhoneQueryBuilder
            .ApplySort(SamplePhones.AsQueryable(), PhoneSortOption.PriceDescending)
            .ToList();

        Assert.Equal(1500m, result[0].Price);
        Assert.Equal(1100m, result[^1].Price);
    }
}
