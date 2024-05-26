using System.Reflection;
using System.Text.Json;
using Domain;
using Domain.OrderAggregate;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (!userManager.Users.Any())
            {
                var tmpData = File.ReadAllText(path + @"/SeedData/users.json");
                var users = JsonSerializer.Deserialize<List<AppUser>>(tmpData);

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }

            if (!context.Models.Any())
            {
                var tmpData = File.ReadAllText(path + @"/SeedData/models.json");
                var models = JsonSerializer.Deserialize<List<Model>>(tmpData);
                await context.Models.AddRangeAsync(models);
            }

            if (!context.AppCompanies.Any())
            {
                var tmpData = File.ReadAllText(path + @"/SeedData/company.json");
                var company = JsonSerializer.Deserialize<AppCompany>(tmpData);
                await context.AppCompanies.AddAsync(company);
            }

            if (!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText(path + @"/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrands.AddRange(brands);
            }

            if (!context.ProductTypes.Any())
            {
                var typesData = File.ReadAllText(path + @"/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                context.ProductTypes.AddRange(types);
            }

            if (!context.Products.Any())
            {
                var productsData = File.ReadAllText(path + @"/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRange(products);
            }

            if (!context.DeliveryMethods.Any())
            {
                var deliveryData = File.ReadAllText(path + @"/SeedData/delivery.json");
                var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryData);
                context.DeliveryMethods.AddRange(methods);
            }

            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}
