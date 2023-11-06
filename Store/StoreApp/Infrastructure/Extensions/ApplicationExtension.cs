using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories;

namespace StoreApp.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext context = app
                .ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<RepositoryContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }



        }

        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(options =>
            {

                options.AddSupportedCultures("tr-TR")
                .AddSupportedUICultures("tr-TR");
            });

        }

        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            const string adminUser = "admin";
            const string adminPassword = "tuna+123";
            //UserManager
            UserManager<IdentityUser> userManager = app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<UserManager<IdentityUser>>();

            //RoleManager

            RoleManager<IdentityRole> rolemanager = app
            .ApplicationServices
            .CreateAsyncScope()
            .ServiceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();
            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            if (user is null)
            {
                user = new IdentityUser(adminUser)
                {
                    Email = "tunagul44@gmail.com",
                    PhoneNumber = "905396702838",
                    UserName = adminUser,
                    EmailConfirmed = true

                };
                var result = await userManager.CreateAsync(user, adminPassword);
                if (!result.Succeeded)
                {
                    throw new Exception("Admin user could not created.");
                }
                var roleResult = await userManager.AddToRolesAsync(user,
                rolemanager
                .Roles
                .Select(r=>r.Name)
                .ToList()
                );
                if(!roleResult.Succeeded)
                    throw new Exception("System habe problems with role defination for admin.");
            }


        }
    }
}