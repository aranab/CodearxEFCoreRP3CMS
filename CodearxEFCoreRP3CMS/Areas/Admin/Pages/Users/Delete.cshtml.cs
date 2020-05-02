using CodearxEFCoreRP3CMS.Areas.Admin.Services;
using CodearxEFCoreRP3CMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Areas.Admin.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly UserService _users;

        public DeleteModel(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _users = new UserService(ModelState, userRepository, roleRepository);
        }

        // URL: {domain}/admin/users/delete/get-to-delete
        //public async Task<IActionResult> OnGetAsync(string username)
        //{
        //}

        // URL: {domain}/admin/users/delete/post-to-delete
        public async Task<IActionResult> OnPostAsync(string username)
        {
            await _users.DeleteAsync(username);

            return RedirectToPage("./Index");
        }
    }
}
