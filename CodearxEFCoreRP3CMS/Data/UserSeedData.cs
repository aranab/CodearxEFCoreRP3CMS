using CodearxEFCoreRP3CMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Data
{
    public class InitialUserInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
    }

    public static class UserSeedData
    {
        public static async Task Initialize(IServiceProvider services)
        {
            var userList = services.GetRequiredService<IConfiguration>().GetSection("UserList").Get<List<InitialUserInfo>>();
            var userManager = services.GetService<UserManager<CmsUser>>();

            foreach (var userInfo in userList)
            {
                await EnsureUser(userManager, userInfo);
            }

            var roleList = services.GetRequiredService<IConfiguration>().GetSection("RoleList").Get<List<string>>();
            var roleManager = services.GetService<RoleManager<IdentityRole>>();

            foreach (var roleName in roleList)
            {
                await EnsureRole(roleManager, roleName);
            }
        }

        private static async Task EnsureUser(UserManager<CmsUser> userManager, InitialUserInfo userInfo)
        {
            var user = await userManager.FindByNameAsync(userInfo.UserName);

            if (user == null)
            {
                user = new CmsUser
                {
                    UserName = userInfo.UserName,
                    Email = userInfo.Email,
                    DisplayName = userInfo.DisplayName,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(user, userInfo.Password);
            }
        }

        private static async Task EnsureRole(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }
}
