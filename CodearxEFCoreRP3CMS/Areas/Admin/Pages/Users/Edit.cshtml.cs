using CodearxEFCoreRP3CMS.Areas.Admin.Services;
using CodearxEFCoreRP3CMS.Areas.Admin.ViewModels;
using CodearxEFCoreRP3CMS.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Areas.Admin.Pages.Users
{
    [Authorize(Roles = "admin, editor, author")]
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
            var currentUser = User.Identity.Name;

            if (!User.IsInRole("admin") &&
                !string.Equals(currentUser, username, StringComparison.CurrentCultureIgnoreCase))
            {
                return Unauthorized();
            }

            Input = await _users.GetUserByNameAsync(username);

            if (Input == null)
            {
                return NotFound();
            }

            return Page();
        }

        // URL: {domain}/admin/users/edit/post-to-edit
        public async Task<IActionResult> OnPostAsync(string username)
        {
            var currentUser = User.Identity.Name;
            var isAdmin = User.IsInRole("admin");

            if (!isAdmin &&
                !string.Equals(currentUser, username, StringComparison.CurrentCultureIgnoreCase))
            {
                return Unauthorized();
            }

            var userUpdated = await _users.UpdateAsync(Input);

            if (userUpdated)
            {
                if (isAdmin)
                {
                    return RedirectToPage("./Index");
                }

                return RedirectToPage("../Index");                
            }

            return Page();
        }
    }
}
