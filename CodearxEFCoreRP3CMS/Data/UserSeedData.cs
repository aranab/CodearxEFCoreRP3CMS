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
                var userId = await EnsureUser(userManager, userInfo);
            }
        }

        private static async Task<string> EnsureUser(UserManager<CmsUser> userManager, InitialUserInfo userInfo)
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

            return user.Id;
        }
    }
}
