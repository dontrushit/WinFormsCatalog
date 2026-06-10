namespace WinFormsCatalog.Data.Entities;

public class ShopEntity
{
    public int Id { get; set; }
    public int PhoneId { get; set; }
    public string Shop { get; set; } = "";
    public decimal Price { get; set; }

    public PhoneEntity Phone { get; set; } = null!;
}
