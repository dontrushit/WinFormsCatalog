using WinFormsCatalog.Models;

namespace WinFormsCatalog.Tests;

public class OrderServiceTests
{
    [Fact]
    public void CreateOrder_SavesToDatabase()
    {
        if (!IntegrationTestFixture.IsDatabaseAvailable())
            return;

        var service = IntegrationTestFixture.CreateCatalogService();
        var orderId = service.CreateOrder(new OrderRequest
        {
            PhoneId = 1,
            ShopName = "DNS",
            UnitPrice = 1150m,
            Quantity = 2,
            CustomerName = "Тестов Тест Тестович",
            CustomerPhone = "+375291234567",
            Address = "Минск, тестовая улица, 1"
        });

        Assert.True(orderId > 0);
    }
}
