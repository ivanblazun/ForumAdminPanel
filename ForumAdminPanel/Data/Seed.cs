using ForumAdminPanel.Data.Enum;
using ForumAdminPanel.Models;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.Net;

namespace ForumAdminPanel.Data
{
    
        public class Seed
        {    
            public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
            {
                using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
                {
                    //Roles
                    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                    if (!await roleManager.RoleExistsAsync(UserRoles.User))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                    //Users
                    var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AdminAppUser>>();

                    // admin
                    string adminUserEmail = "teddysmithdeveloper@gmail.com";

                    var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                    if (adminUser == null)
                    {
                        var newAdminUser = new AdminAppUser()
                        {
                            UserName = "teddysmithdev",
                            Email = adminUserEmail,
                            EmailConfirmed = true,
                  
                        };
                        await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                        await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                    }


                    // user
                    //string appUserEmail = "user@etickets.com";

                    //var appUser = await userManager.FindByEmailAsync(appUserEmail);
                    //if (appUser == null)
                    //{
                    //    var newAppUser = new AdminAppUser()
                    //    {
                    //        UserName = "app-user",
                    //        Email = appUserEmail,
                    //        EmailConfirmed = true,
                     
                    //    };
                    //    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    //    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                    //}
                }
            }
        }
    
}
