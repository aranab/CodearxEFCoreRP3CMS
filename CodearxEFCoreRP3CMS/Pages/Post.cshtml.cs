using CodearxEFCoreRP3CMS.Data;
using CodearxEFCoreRP3CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Pages
{
    public class PostModel : PageModel
    {
        private readonly IPostRepository _posts;

        public PostModel(IPostRepository postRepository)
        {
            _posts = postRepository;
        }

        public Post Post { get; private set;  }

        // URL: {domain}/post/post-id
        public async Task<IActionResult> OnGetAsync(string postId)
        {
            Post = await _posts.GetAsync(postId);

            if (Post == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}