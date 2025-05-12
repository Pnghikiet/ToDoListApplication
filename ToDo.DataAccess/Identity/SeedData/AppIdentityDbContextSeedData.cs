using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApplication.DataAccess.Identity.SeedData
{
    public static class AppIdentityDbContextSeedData
    {
        public static async Task SeedDataAsync(UserManager<IdentityUser> usermange)
        {
            if(!usermange.Users.Any())
            {
                var user = new IdentityUser
                {
                    Email = "pnk@test.com",
                    UserName = "pnk@test.com"
                };

                await usermange.CreateAsync(user, "Pnk17092001!");
            }
        }
    }
}
