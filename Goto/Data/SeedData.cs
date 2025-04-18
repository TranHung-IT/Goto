using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Goto.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            string[] roles = { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var adminUser = new IdentityUser { UserName = "admin123@gmail.com", Email = "admin123@gmail.com" };
            if (await userManager.FindByEmailAsync("admin123@gmail.com") == null)
            {
                await userManager.CreateAsync(adminUser, "Admin123@");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
