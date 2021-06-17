using Behelit.Data.Context;
using Behelit.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Behelit.Data.Seeding
{
    public class SeedDB
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<BehelitDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                var user1 = new ApplicationUser { 
                    UserName = "lyncee", 
                    Email = "guillaume.marquilly@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString()           
                };
                userManager.CreateAsync(user1, "123");

                var user2 = new ApplicationUser { 
                    UserName = "inwyi", 
                    Email = "matthieu.marquilly@gmail.com", 
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                userManager.CreateAsync(user2, "123");
            }
        }
    }
}
