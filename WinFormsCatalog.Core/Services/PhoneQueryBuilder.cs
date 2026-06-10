using WinFormsCatalog.Models;

namespace WinFormsCatalog.Services;

public static class PhoneQueryBuilder
{
    public static IQueryable<Phone> ApplyFilters(IQueryable<Phone> query, PhoneFilterCriteria criteria)
    {
        if (criteria.Producers.Count > 0)
            query = query.Where(phone => criteria.Producers.Contains(phone.Producer));

        if (!string.IsNullOrWhiteSpace(criteria.Os))
            query = query.Where(phone => phone.Os == criteria.Os);

        query = query.Where(phone => phone.Price >= criteria.PriceMin && phone.Price <= criteria.PriceMax);

        if (criteria.OnlyInStock)
            query = query.Where(phone => phone.InStock);

        if (criteria.MinRamGb > 0)
            query = query.Where(phone => phone.RamGb >= criteria.MinRamGb);

        if (criteria.MinStorageGb > 0)
            query = query.Where(phone => phone.StorageGb >= criteria.MinStorageGb);

        if (!string.IsNullOrWhiteSpace(criteria.Search))
        {
            string search = criteria.Search.Trim().ToLower();
            query = query.Where(phone =>
                phone.Name.ToLower().Contains(search) ||
                phone.Producer.ToLower().Contains(search));
        }

        return query;
    }

    public static IQueryable<Phone> ApplySort(IQueryable<Phone> query, PhoneSortOption sort) =>
        sort switch
        {
            PhoneSortOption.PriceDescending => query.OrderByDescending(phone => phone.Price),
            PhoneSortOption.NameAscending => query.OrderBy(phone => phone.Name),
            PhoneSortOption.NameDescending => query.OrderByDescending(phone => phone.Name),
            PhoneSortOption.RamAscending => query.OrderBy(phone => phone.RamGb),
            PhoneSortOption.RamDescending => query.OrderByDescending(phone => phone.RamGb),
            _ => query.OrderBy(phone => phone.Price)
        };
}
