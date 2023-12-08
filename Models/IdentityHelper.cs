using Microsoft.AspNetCore.Identity;

namespace Catopia.Models
{
    public class IdentityHelper
    {
        public const string Admin = "admin";
        public const string Client = "client";

        public static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            RoleManager<IdentityRole> rManager = provider.GetService<RoleManager<IdentityRole>>();

            foreach (string role in roles)
            {
                bool doesRoleExist = await rManager.RoleExistsAsync(role);
                if (!doesRoleExist)
                {
                    await rManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        public static async Task CreateDefaultAdmin(IServiceProvider provider, string role)
        {
            var uMananger = provider.GetService<UserManager<IdentityUser>>();

            int numUsers = (await uMananger.GetUsersInRoleAsync(role)).Count();
            if (numUsers == 0)
            {
                var defaultAdmin = new IdentityUser()
                {
                    Email = "webadmin@catopia.org",
                    UserName = "webadmin@catopia.org"
                };

                await uMananger.CreateAsync(defaultAdmin, "CatScratch2#");
                await uMananger.AddToRoleAsync(defaultAdmin, role);
            }
        }
    }
}
