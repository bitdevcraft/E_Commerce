using System.Reflection;
using Domain;
using Domain.OrderAggregate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Model> Models { get; set; }
        public DbSet<AppCompany> AppCompanies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Delivery Method Configuration
            builder.Entity<DeliveryMethod>(b =>
            {
                b.Property(d => d.Price).HasColumnType("decimal(18,2)");
            });

            // Order Configuration
            builder.Entity<Order>(b =>
            {
                b.OwnsOne(
                    o => o.ShipToAddress,
                    a =>
                    {
                        a.WithOwner();
                    }
                );
                b.Navigation(a => a.ShipToAddress).IsRequired();
                b.Property(s => s.Status)
                    .HasConversion(
                        o => o.ToString(),
                        o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o)
                    );
                b.HasMany(o => o.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
            });

            // OrderItem Configuration
            builder.Entity<OrderItem>(b =>
            {
                b.OwnsOne(
                    i => i.ItemOrdered,
                    io =>
                    {
                        io.WithOwner();
                    }
                );

                b.Property(i => i.Price).HasColumnType("decimal(18,2)");
            });

            // Product Configuration
            builder.Entity<Product>(b =>
            {
                b.Property(p => p.Id).IsRequired();
                b.Property(p => p.Name).IsRequired().HasMaxLength(100);
                b.Property(p => p.Description).IsRequired();
                b.Property(p => p.Price).HasColumnType("decimal(18,2)");
                b.Property(p => p.PictureUrl).IsRequired();
                b.HasOne(p => p.ProductBrand).WithMany().HasForeignKey(p => p.ProductBrandId);
                b.HasOne(p => p.ProductType).WithMany().HasForeignKey(p => p.ProductTypeId);
            });

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in builder.Model.GetEntityTypes())
                {
                    var properties = entityType
                        .ClrType.GetProperties()
                        .Where(p => p.PropertyType == typeof(decimal));

                    foreach (var property in properties)
                    {
                        builder
                            .Entity(entityType.Name)
                            .Property(property.Name)
                            .HasConversion<double>();
                    }
                }
            }
        }
    }
}
