using CodearxEFCoreRP3CMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<CmsUser> _userManager;

        public UserRepository(UserManager<CmsUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CmsUser> GetUserByNameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<IList<CmsUser>> GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task CreateAsync(CmsUser user, string password)
        {
            await _userManager.CreateAsync(user, password);
        }

        public async Task DeleteAsync(CmsUser user)
        {
            await _userManager.DeleteAsync(user);
        }

        public async Task<IdentityResult> UpdateAsync(CmsUser user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<bool> VerifyUserPasswordAsync(CmsUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public string HashPassword(CmsUser user, string password)
        {
            return _userManager.PasswordHasher.HashPassword(user, password);
        }

        public async Task AddUserToRoleAsync(CmsUser user, string role)
        {
            await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<IList<string>> GetRolesForUserAsync(CmsUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task RemoveUserFromRoleAsync(CmsUser user, params string[] roleNames)
        {
            await _userManager.RemoveFromRolesAsync(user, roleNames);
        }

        private bool _disposed = false;
        public void Dispose()
        {
            if (!_disposed)
            {
                _userManager.Dispose();
            }

            _disposed = true;
        }        
    }
}
