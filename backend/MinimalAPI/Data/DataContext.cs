using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Models.Entities;
using MinimalAPI.Models.Identity;

namespace MinimalAPI.Data;

public class DataContext : IdentityDbContext<User>
{
    public DataContext(DbContextOptions options)
        : base(options) { }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<ProductImage> ProductImages => Set<ProductImage>();
    public DbSet<Size> Sizes => Set<Size>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<OrderStatus> OrderStatuses => Set<OrderStatus>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Category>().HasIndex(x => x.Name).IsUnique();
        builder.Entity<Tag>().HasIndex(x => x.Name).IsUnique();
        builder.Entity<Size>().HasIndex(x => x.Name).IsUnique();

        builder.Entity<Product>()
            .HasMany(e => e.Tags)
            .WithMany(e => e.Products)
            .UsingEntity("ProductTags");
        builder.Entity<Product>()
            .HasMany(e => e.AvailableSizes)
            .WithMany(e => e.Products)
            .UsingEntity("ProductSizes");

        Seeder.SeedAll(builder);
    }
}
