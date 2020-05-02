using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Data
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleRepository(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IdentityRole> GetRoleByNameAsync(string name)
        {
            return await _roleManager.FindByNameAsync(name);
        }

        public async Task<IList<IdentityRole>> GetAllRolesAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task CreateAsync(IdentityRole role)
        {
            await _roleManager.CreateAsync(role);
        }

        private bool _disposed = false;
        public void Dispose()
        {
            if(!_disposed)
            {
                _roleManager.Dispose();
            }

            _disposed = true;
        }
    }
}
