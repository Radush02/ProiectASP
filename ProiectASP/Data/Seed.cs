using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.Net;
using TemaASP.Models.Enum;

namespace TemaASP.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDBContext>();
                context.Database.EnsureCreated();
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //adaugat roluri
            }
        }
    }
}
