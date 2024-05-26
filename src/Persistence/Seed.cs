using System.Reflection;
using System.Text.Json;
using Domain;
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
                // var company = new AppCompany
                // {
                //     Logo =
                //         "/Files/Uploaded/Images/vite.svg",
                //     Name = "Default Company",
                //     Email = "defaultcompany@test.com",
                //     MobileNo = "000-000-000",
                //     Hotline = "000-000-000",
                //     About =
                //         "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                //     Vision =
                //         "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                //     Mission =
                //         "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                //     Address = "City, Country",
                // };

                await context.AppCompanies.AddAsync(company);
            }


            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}
