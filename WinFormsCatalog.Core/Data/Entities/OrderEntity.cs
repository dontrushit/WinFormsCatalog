namespace WinFormsCatalog.Data.Entities;

public class OrderEntity
{
    public int Id { get; set; }
    public int PhoneId { get; set; }
    public string ShopName { get; set; } = "";
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public string CustomerName { get; set; } = "";
    public string CustomerPhone { get; set; } = "";
    public string? Address { get; set; }
    public DateTime CreatedAt { get; set; }

    public PhoneEntity Phone { get; set; } = null!;
}
