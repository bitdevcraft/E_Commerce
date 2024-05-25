using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace UnitTest.Mock
{
    public static class MockData
    {
        public static async Task<DataContext> SetupContext()
        {
            // Create a mock context with InMemory database
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase") // Use a unique name for the database
                .Options;

            var context = new DataContext(options);

            // Mock UserManager
            var store = new Mock<IUserStore<AppUser>>();
            var userManager = new UserManager<AppUser>(
                store.Object,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                null
            );

            // Seed some data
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
                user.PasswordHash = "Pa$$w0rd";
                await context.Users.AddAsync(user);
            }

            var models = new List<Model>
            {
                new Model { Title = "Model 1", Description = "Description Model 1" },
                new Model { Title = "Model 2", Description = "Description Model 2" },
                new Model { Title = "Model 3", Description = "Description Model 3" },
            };

            await context.Models.AddRangeAsync(models);
            await context.SaveChangesAsync();

            return context;
        }
    }
}
