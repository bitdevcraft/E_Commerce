using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        FirstName = "Admin",
                        LastName = "",
                        UserName = "admin",
                        Email = "admin@test.com"
                    },
                    new AppUser
                    {
                        FirstName = "User",
                        LastName = "",
                        UserName = "user",
                        Email = "user@test.com"
                    },
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }

            if (context.Models.Any())
                return;

            var models = new List<Model>
            {
                new Model { Title = "Model 1", Description = "Description Model 1" },
                new Model { Title = "Model 2", Description = "Description Model 2" },
                new Model { Title = "Model 3", Description = "Description Model 3" },
            };

            if (context.AppCompanies.Any())
                return;
            var company = new AppCompany
            {
                Logo =
                    "/Files/Uploaded/Images/vite.svg",
                Name = "Default Company",
                Email = "defaultcompany@test.com",
                MobileNo = "000-000-000",
                Hotline = "000-000-000",
                About =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Vision =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Mission =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                Address = "City, Country",
            };

            await context.AppCompanies.AddAsync(company);

            await context.Models.AddRangeAsync(models);
            await context.SaveChangesAsync();
        }
    }
}
