namespace WinFormsCatalog.Data.Entities;

public class PhoneEntity
{
    public int Id { get; set; }
    public string Model { get; set; } = "";

    public CharacteristicEntity? Characteristic { get; set; }
    public ICollection<ShopEntity> Shops { get; set; } = [];
    public ICollection<OrderEntity> Orders { get; set; } = [];
}
