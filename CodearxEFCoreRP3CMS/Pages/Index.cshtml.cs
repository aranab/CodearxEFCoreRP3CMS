using CodearxEFCoreRP3CMS.Data;
using CodearxEFCoreRP3CMS.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IPostRepository _posts;

        public IndexModel(IPostRepository postRepository)
        {
            _posts = postRepository;
        }

        public IList<Post> Posts { get; set; }

        // URL: {domain}/
        public async Task OnGetAsync()
        {
            Posts = await _posts.GetPublishedPostsAsync();
        }
    }
}
