using Microsoft.AspNetCore.Identity;
using NovelNookBookStore.Models.DomainModels;

namespace NovelNookBookStore.Models
{
    public class IdentityConfig
    {
        public static async Task CreateAdminUserAsync(IServiceProvider provider)
        {
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = provider.GetRequiredService<UserManager<ApplicationUser>>();

            string username = "admin@NovelNook.com";
            string password = "AdminEmployee123!";
            string roleName = "Admin";

            if(await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
            if(await userManager.FindByNameAsync(username) == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = username,
                    Email = "Admin@NovelNook.com",
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(user, password); 

                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
    }
}
