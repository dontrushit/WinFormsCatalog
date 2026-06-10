namespace WinFormsCatalog.Models;

public class OrderRequest
{
    public int PhoneId { get; set; }
    public string ShopName { get; set; } = "";
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public string CustomerName { get; set; } = "";
    public string CustomerPhone { get; set; } = "";
    public string? Address { get; set; }
}
