using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Helpers.Seeders;
using MinimalAPI.Models.Entities;

namespace MinimalAPI.Data;

public class DataContext : IdentityDbContext<IdentityUser>
{
    public DataContext(DbContextOptions options)
        : base(options) { }

    public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
    public DbSet<ProductEntity> Products => Set<ProductEntity>();
    public DbSet<ProductImageEntity> ProductImages => Set<ProductImageEntity>();
    public DbSet<SizeEntity> Sizes => Set<SizeEntity>();
    public DbSet<TagEntity> Tags => Set<TagEntity>();
    public DbSet<AddressEntity> Addresses => Set<AddressEntity>();
    public DbSet<CustomerEntity> Customers => Set<CustomerEntity>();
    public DbSet<OrderItemEntity> OrderItems => Set<OrderItemEntity>();
    public DbSet<OrderStatusEntity> OrderStatuses => Set<OrderStatusEntity>();
    public DbSet<OrderEntity> Orders => Set<OrderEntity>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<CategoryEntity>().HasIndex(x => x.Name).IsUnique();
        builder.Entity<TagEntity>().HasIndex(x => x.Name).IsUnique();
        builder.Entity<SizeEntity>().HasIndex(x => x.Name).IsUnique();

        builder.Entity<ProductEntity>()
            .HasMany(e => e.Tags)
            .WithMany(e => e.Products)
            .UsingEntity("ProductTags");
        builder.Entity<ProductEntity>()
            .HasMany(e => e.AvailableSizes)
            .WithMany(e => e.Products)
            .UsingEntity("ProductSizes");

        Seeder.SeedAll(builder);
    }
}
