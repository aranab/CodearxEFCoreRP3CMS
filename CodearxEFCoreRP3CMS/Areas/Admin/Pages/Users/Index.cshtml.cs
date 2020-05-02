using CodearxEFCoreRP3CMS.Data;
using CodearxEFCoreRP3CMS.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Areas.Admin.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        public IndexModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IList<CmsUser> Users { get; set; }

        // URL: {domain}/admin/users
        public async Task OnGetAsync()
        {
            Users = await _userRepository.GetAllUsersAsync();
        }
    }
}
