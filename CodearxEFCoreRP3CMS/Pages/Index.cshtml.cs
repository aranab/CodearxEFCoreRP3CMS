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
        private readonly int _pageSize = 2;

        public IndexModel(IPostRepository postRepository)
        {
            _posts = postRepository;
        }

        public int PreviousPage { get; set; }
        public int NextPage { get; set; }
        public IList<Post> Posts { get; set; }

        // URL: {domain}/
        public async Task OnGetAsync(int? pageNumber)
        {
            var pageIndex = 1;
            if (pageNumber != null)
            {
                pageIndex = (int)pageNumber;
            }

            PreviousPage = (pageIndex - 1);
            NextPage = (decimal.Divide(_posts.CountPublished, _pageSize) > pageIndex) ? pageIndex + 1 : -1;

            Posts = await _posts.GetPageAsync(pageIndex, _pageSize);
        }
    }
}
