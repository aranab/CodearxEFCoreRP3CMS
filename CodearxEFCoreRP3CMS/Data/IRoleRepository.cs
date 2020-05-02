using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Data
{
    public interface IRoleRepository : IDisposable
    {
        Task<IdentityRole> GetRoleByNameAsync(string name);
        Task<IList<IdentityRole>> GetAllRolesAsync();
        Task CreateAsync(IdentityRole role);
    }
}
