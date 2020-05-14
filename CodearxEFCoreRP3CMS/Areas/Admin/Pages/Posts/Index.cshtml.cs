using CodearxEFCoreRP3CMS.Data;
using CodearxEFCoreRP3CMS.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Areas.Admin.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly IPostRepository _repository;
        private readonly IUserRepository _user;

        public IndexModel(IPostRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _user = userRepository;
        }

        public IList<Post> Posts { get; set; }

        // URL: {domain}/admin/post
        public async Task OnGetAsync()
        {
            Posts = !User.IsInRole("author")
                ? await _repository.GetAllAsync()
                : await _repository.GetPostsByAuthorAsync(_user.GetUserId(User));
        }
    }
}
