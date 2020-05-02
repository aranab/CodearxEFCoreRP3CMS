using CodearxEFCoreRP3CMS.Areas.Admin.Services;
using CodearxEFCoreRP3CMS.Areas.Admin.ViewModels;
using CodearxEFCoreRP3CMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Areas.Admin.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly UserService _users;
        private readonly IRoleRepository _roleRepository;

        public CreateModel(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
            _users = new UserService(ModelState, userRepository, roleRepository);
        }

        [BindProperty]
        public UserViewModel Input { get; set; }

        // URL: {domain}/admin/users/create
        public async Task OnGetAsync()
        {
            Input = new UserViewModel();
            Input.LoadUserRoles(await _roleRepository.GetAllRolesAsync());
        }        

        // URL: {domain}/admin/users/create/post-to-create
        public async Task<IActionResult> OnPostAsync()
        {
            var completed = await _users.CreateAsync(Input);

            if (completed)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
