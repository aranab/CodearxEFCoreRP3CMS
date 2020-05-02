using CodearxEFCoreRP3CMS.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Data
{
    public interface IUserRepository : IDisposable
    {
        Task<CmsUser> GetUserByNameAsync(string username);
        Task<IList<CmsUser>> GetAllUsersAsync();
        Task CreateAsync(CmsUser user, string password);
        Task DeleteAsync(CmsUser user);
        Task<IdentityResult> UpdateAsync(CmsUser user);
        Task<bool> VerifyUserPasswordAsync(CmsUser user, string password);
        string HashPassword(CmsUser user, string password);
        Task AddUserToRoleAsync(CmsUser user, string role);
        Task<IList<string>> GetRolesForUserAsync(CmsUser user);
        Task RemoveUserFromRoleAsync(CmsUser user, params string[] roleNames);
    }
}
