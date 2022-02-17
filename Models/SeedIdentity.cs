using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CodeSec.Models
{
    public class SeedIdentity
    {
      //task that ensures that there are roles and users in the site
        public static async Task EnsurePopulated(IServiceProvider services)
        {
      //Dependency Injection is used to support checklist: 1 (use existing libraries and frameworks)
      var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            await CreateRoles(roleManager); //CreateRoles needs to be before CreateUsers
            await CreateUsers(userManager);
        }
    //task that creates roles
        private static async Task CreateRoles(RoleManager<IdentityRole> rManager)
        {
            if (!await rManager.RoleExistsAsync("ExecutiveEmployee"))
            {
                await rManager.CreateAsync(new IdentityRole("ExecutiveEmployee"));
            }
            if (!await rManager.RoleExistsAsync("RegularEmployee"))
            {
                await rManager.CreateAsync(new IdentityRole("RegularEmployee"));
            }
            if (!await rManager.RoleExistsAsync("Admin"))
            {
                await rManager.CreateAsync(new IdentityRole("Admin"));
            }
        }

    //task that creates users
        private static async Task CreateUsers(UserManager<IdentityUser> uManager)
        {
      IdentityUser E001 = new IdentityUser("E001");
      IdentityUser E100 = new IdentityUser("E100");
      IdentityUser E101 = new IdentityUser("E101");
      IdentityUser E102 = new IdentityUser("E102");
      IdentityUser E103 = new IdentityUser("E103");
      IdentityUser E200 = new IdentityUser("E200");
      IdentityUser E201 = new IdentityUser("E201");
      IdentityUser E202 = new IdentityUser("E202");
      IdentityUser E203 = new IdentityUser("E203");
      IdentityUser E300 = new IdentityUser("E300");
      IdentityUser E301 = new IdentityUser("E301");
      IdentityUser E302 = new IdentityUser("E302");
      IdentityUser E303 = new IdentityUser("E303");

      await uManager.CreateAsync(E001, "SecurePass001!");
      await uManager.CreateAsync(E101, "SecurePass101!");
      await uManager.CreateAsync(E102, "SecurePass102!");
      await uManager.CreateAsync(E201, "SecurePass201!");
      await uManager.CreateAsync(E202, "SecurePass202!");
      await uManager.CreateAsync(E301, "SecurePass301!");
      await uManager.CreateAsync(E302, "SecurePass302!");

      await uManager.AddToRoleAsync(E001, "Admin");
      await uManager.AddToRoleAsync(E101, "ExecutiveEmployee");
      await uManager.AddToRoleAsync(E102, "RegularEmployee");
      await uManager.AddToRoleAsync(E201, "ExecutiveEmployee");
      await uManager.AddToRoleAsync(E202, "RegularEmployee");
      await uManager.AddToRoleAsync(E301, "ExecutiveEmployee");
      await uManager.AddToRoleAsync(E302, "RegularEmployee");
    }
    }
}
