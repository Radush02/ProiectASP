using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.Net;
using ProiectASP.Models;
using ProiectASP.Models.Enum;
    
namespace ProiectASP.Data
{
    public class Seed
    {

        public static async Task InitializeRoles(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
                foreach (var roleName in Enum.GetNames(typeof(UserRoles)))
                {
                    var roleExist = await roleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                        await roleManager.CreateAsync(new IdentityRole<int>(roleName));
                }
            }
        }
    }
}
