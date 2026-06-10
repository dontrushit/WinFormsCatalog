using WinFormsCatalog.Models;

namespace WinFormsCatalog.Tests;

public class CatalogServiceIntegrationTests
{
    [Fact]
    public void Search_ReturnsSeededCatalog_WhenDatabaseIsAvailable()
    {
        if (!IntegrationTestFixture.IsDatabaseAvailable())
            return;

        var service = IntegrationTestFixture.CreateCatalogService();
        var phones = service.Search(new PhoneFilterCriteria());

        Assert.Equal(17, phones.Count);
        Assert.Contains(phones, phone => phone.Name.Contains("Xiaomi Redmi Note 15 Pro", StringComparison.Ordinal));
        Assert.All(phones, phone => Assert.True(phone.Price > 0));
    }

    [Fact]
    public void Search_FiltersByProducerInDatabase()
    {
        if (!IntegrationTestFixture.IsDatabaseAvailable())
            return;

        var service = IntegrationTestFixture.CreateCatalogService();
        var phones = service.Search(new PhoneFilterCriteria
        {
            Producers = ["Xiaomi"]
        });

        Assert.NotEmpty(phones);
        Assert.All(phones, phone => Assert.Equal("Xiaomi", phone.Producer));
    }

    [Fact]
    public void GetShopOffers_ReturnsPricesOrderedByValue()
    {
        if (!IntegrationTestFixture.IsDatabaseAvailable())
            return;

        var service = IntegrationTestFixture.CreateCatalogService();
        var offers = service.GetShopOffers(1);

        Assert.Equal(3, offers.Count);
        Assert.Equal("DNS", offers[0].Shop);
        Assert.Equal(1150m, offers[0].Price);
        Assert.True(offers[^1].Price >= offers[0].Price);
    }
}
