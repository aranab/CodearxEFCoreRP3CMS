using CodearxEFCoreRP3CMS.Areas.Admin.Services;
using CodearxEFCoreRP3CMS.Areas.Admin.ViewModels;
using CodearxEFCoreRP3CMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Areas.Admin.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly UserService _users;

        public EditModel(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _users = new UserService(ModelState, userRepository, roleRepository);
        }

        [BindProperty]
        public UserViewModel Input { get; set; }

        // URL: {domain}/admin/users/edit/get-to-edit
        public async Task<IActionResult> OnGetAsync(string username)
        {
            Input = await _users.GetUserByNameAsync(username);

            if (Input == null)
            {
                return NotFound();
            }

            return Page();
        }

        // URL: {domain}/admin/users/edit/post-to-edit
        public async Task<IActionResult> OnPostAsync()
        {
            var userUpdated = await _users.UpdateAsync(Input);

            if (userUpdated)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
