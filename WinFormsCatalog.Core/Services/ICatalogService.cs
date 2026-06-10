using WinFormsCatalog.Models;

namespace WinFormsCatalog.Services;

public interface ICatalogService
{
    CatalogFilterOptions GetFilterOptions();
    IReadOnlyList<Phone> Search(PhoneFilterCriteria criteria);
    IReadOnlyList<ShopOffer> GetShopOffers(int phoneId);
    int CreateOrder(OrderRequest order);
}
