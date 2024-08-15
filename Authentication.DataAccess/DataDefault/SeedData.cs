using Authentication.DataAccess.EntityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.DataAccess.DataDefault
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {


                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                //  role
                var role = "SuperAdmin";
                var roleExists = await roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    var roleNew = new IdentityRole(role);
                    roleNew.Name = role;
                    await roleManager.CreateAsync(roleNew);
                }
                //user
                var user = new ApplicationUser
                {
                    UserName = "1",
                    Email = "thinh48691953@gmail.com",
                    PhoneNumber = "0359342009",
                    DisplayName = "Super Admin",
                    Avatar = "",
                };

                var userExists = await userManager.FindByEmailAsync(user.Email);
                if (userExists == null)
                {
                    var result = await userManager.CreateAsync(user, "Pass123!");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, role);
                    }
                }
            }
        }
    }
}
