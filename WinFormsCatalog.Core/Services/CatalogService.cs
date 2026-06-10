using Microsoft.EntityFrameworkCore;
using WinFormsCatalog.Data;
using WinFormsCatalog.Data.Entities;
using WinFormsCatalog.Models;

namespace WinFormsCatalog.Services;

public sealed class CatalogService : ICatalogService
{
    private readonly IDbContextFactory<CatalogDbContext> _contextFactory;

    public CatalogService(IDbContextFactory<CatalogDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public CatalogFilterOptions GetFilterOptions()
    {
        using var context = _contextFactory.CreateDbContext();

        var characteristics = context.Characteristics.AsNoTracking();

        return new CatalogFilterOptions
        {
            Producers = characteristics
                .Where(item => item.Producer != "")
                .Select(item => item.Producer)
                .Distinct()
                .OrderBy(item => item)
                .ToList(),
            OperatingSystems = characteristics
                .Select(item => item.Os)
                .Distinct()
                .OrderBy(item => item)
                .ToList(),
            MaxPrice = context.Shops.AsNoTracking().Max(shop => (decimal?)shop.Price) ?? 0,
            MaxRamGb = characteristics.Max(item => (int?)item.RamGb) ?? 0,
            MaxStorageGb = characteristics.Max(item => (int?)item.StorageGb) ?? 0
        };
    }

    public IReadOnlyList<Phone> Search(PhoneFilterCriteria criteria)
    {
        using var context = _contextFactory.CreateDbContext();

        var query = BuildPhoneQuery(context);
        query = PhoneQueryBuilder.ApplyFilters(query, criteria);
        query = PhoneQueryBuilder.ApplySort(query, criteria.Sort);

        return query.ToList();
    }

    public IReadOnlyList<ShopOffer> GetShopOffers(int phoneId)
    {
        using var context = _contextFactory.CreateDbContext();

        return context.Shops
            .AsNoTracking()
            .Where(shop => shop.PhoneId == phoneId)
            .OrderBy(shop => shop.Price)
            .Select(shop => new ShopOffer
            {
                Shop = shop.Shop,
                Price = shop.Price
            })
            .ToList();
    }

    public int CreateOrder(OrderRequest order)
    {
        using var context = _contextFactory.CreateDbContext();

        var entity = new OrderEntity
        {
            PhoneId = order.PhoneId,
            ShopName = order.ShopName,
            UnitPrice = order.UnitPrice,
            Quantity = order.Quantity,
            CustomerName = order.CustomerName,
            CustomerPhone = order.CustomerPhone,
            Address = order.Address,
            CreatedAt = DateTime.UtcNow
        };

        context.Orders.Add(entity);
        context.SaveChanges();
        return entity.Id;
    }

    private static IQueryable<Phone> BuildPhoneQuery(CatalogDbContext context) =>
        context.Phones
            .AsNoTracking()
            .Where(phone => phone.Characteristic != null)
            .Select(phone => new Phone
            {
                Id = phone.Id,
                Name = phone.Model,
                Producer = phone.Characteristic!.Producer,
                Os = phone.Characteristic.Os,
                ScreenSize = phone.Characteristic.ScreenSize,
                RamGb = phone.Characteristic.RamGb,
                StorageGb = phone.Characteristic.StorageGb,
                ImageUrl = phone.Characteristic.ImageUrl,
                InStock = phone.Characteristic.InStock,
                ScreenTech = phone.Characteristic.ScreenTech,
                ScreenResolution = phone.Characteristic.ScreenResolution,
                ScreenRefreshHz = phone.Characteristic.ScreenRefreshHz,
                Processor = phone.Characteristic.Processor,
                CameraMp = phone.Characteristic.CameraMp,
                BatteryMah = phone.Characteristic.BatteryMah,
                Waterproof = phone.Characteristic.Waterproof,
                Description = phone.Characteristic.Description,
                Price = phone.Shops.Min(shop => (decimal?)shop.Price) ?? 0
            });
}
