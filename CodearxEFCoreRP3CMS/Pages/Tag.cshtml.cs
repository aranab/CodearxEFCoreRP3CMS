using CodearxEFCoreRP3CMS.Data;
using CodearxEFCoreRP3CMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Pages
{
    public class TagModel : PageModel
    {
        private readonly IPostRepository _posts;

        public TagModel(IPostRepository postRepository)
        {
            _posts = postRepository;
        }

        public IList<Post> Posts { get; private set; }
        public string TagName { get; set; }

        // URL: {domain}/tag/tag-id
        public async Task<IActionResult> OnGetAsync(string tagId)
        {
            Posts = await _posts.GetPostsByTagAsync(tagId);

            if (!Posts.Any())
            {
                return NotFound();
            }

            TagName = tagId;

            return Page();
        }
    }
}
