using Microsoft.EntityFrameworkCore;
using WinFormsCatalog.Data.Entities;

namespace WinFormsCatalog.Data;

public class CatalogDbContext : DbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
        : base(options)
    {
    }

    public DbSet<PhoneEntity> Phones => Set<PhoneEntity>();
    public DbSet<CharacteristicEntity> Characteristics => Set<CharacteristicEntity>();
    public DbSet<ShopEntity> Shops => Set<ShopEntity>();
    public DbSet<OrderEntity> Orders => Set<OrderEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PhoneEntity>(entity =>
        {
            entity.ToTable("phones");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Model).HasColumnName("model").HasMaxLength(255).IsRequired();
        });

        modelBuilder.Entity<CharacteristicEntity>(entity =>
        {
            entity.ToTable("characteristics");
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.PhoneId).IsUnique();
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PhoneId).HasColumnName("phone_id");
            entity.Property(e => e.Producer).HasColumnName("producer").HasMaxLength(100);
            entity.Property(e => e.Os).HasColumnName("os").HasMaxLength(50);
            entity.Property(e => e.ScreenSize).HasColumnName("screen_size").HasMaxLength(20);
            entity.Property(e => e.RamGb).HasColumnName("ram_gb");
            entity.Property(e => e.StorageGb).HasColumnName("storage_gb");
            entity.Property(e => e.ImageUrl).HasColumnName("image_url").HasMaxLength(255);
            entity.Property(e => e.InStock).HasColumnName("in_stock");
            entity.Property(e => e.ScreenTech).HasColumnName("screen_tech").HasMaxLength(50);
            entity.Property(e => e.ScreenResolution).HasColumnName("screen_resolution").HasMaxLength(30);
            entity.Property(e => e.ScreenRefreshHz).HasColumnName("screen_refresh_hz");
            entity.Property(e => e.Processor).HasColumnName("processor").HasMaxLength(100);
            entity.Property(e => e.CameraMp).HasColumnName("camera_mp");
            entity.Property(e => e.BatteryMah).HasColumnName("battery_mah");
            entity.Property(e => e.Waterproof).HasColumnName("waterproof").HasMaxLength(50);
            entity.Property(e => e.Description).HasColumnName("description");

            entity.HasOne(e => e.Phone)
                .WithOne(e => e.Characteristic)
                .HasForeignKey<CharacteristicEntity>(e => e.PhoneId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ShopEntity>(entity =>
        {
            entity.ToTable("shops");
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.PhoneId);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PhoneId).HasColumnName("phone_id");
            entity.Property(e => e.Shop).HasColumnName("shop").HasMaxLength(100).IsRequired();
            entity.Property(e => e.Price).HasColumnName("price").HasColumnType("numeric(12,2)");

            entity.HasOne(e => e.Phone)
                .WithMany(e => e.Shops)
                .HasForeignKey(e => e.PhoneId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<OrderEntity>(entity =>
        {
            entity.ToTable("orders");
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.PhoneId);
            entity.HasIndex(e => e.CreatedAt);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.PhoneId).HasColumnName("phone_id");
            entity.Property(e => e.ShopName).HasColumnName("shop_name").HasMaxLength(100).IsRequired();
            entity.Property(e => e.UnitPrice).HasColumnName("unit_price").HasColumnType("numeric(12,2)");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.CustomerName).HasColumnName("customer_name").HasMaxLength(255).IsRequired();
            entity.Property(e => e.CustomerPhone).HasColumnName("customer_phone").HasMaxLength(50).IsRequired();
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.CreatedAt).HasColumnName("created_at");

            entity.HasOne(e => e.Phone)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.PhoneId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
