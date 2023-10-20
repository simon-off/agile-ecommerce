using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPI.Helpers.Seeders;
using WebAPI.Models.Entities;

namespace WebAPI.Data;

public class DataContext : IdentityDbContext<IdentityUser>
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProductImageEntity> ProductImages { get; set; }
    public DbSet<SizeEntity> Sizes { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<AddressEntity> Address { get; set; }
    public DbSet<CustomerEntity> Customer { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderItemEntity> OrderItems { get; set; }
    public DbSet<StatusEntity> Statuses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<CategoryEntity>()
            .HasIndex(x => x.Name)
            .IsUnique();

        builder.Entity<TagEntity>()
            .HasIndex(x => x.Name)
            .IsUnique();

        builder.Entity<SizeEntity>()
            .HasIndex(x => x.Name)
            .IsUnique();

        Seeder.SeedAll(builder);
    }
}
