using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CodearxEFCoreRP3CMS.Data;
using CodearxEFCoreRP3CMS.Models;

namespace CodearxEFCoreRP3CMS.Areas.Admin.Pages.Posts
{
    public class DetailsModel : PageModel
    {
        private readonly IPostRepository _repository;

        public DetailsModel(IPostRepository repository)
        {
            _repository = repository;
        }

        public Post Post { get; set; }

        // URL: {domain}/admin/posts/details/get-to-details
        public async Task<IActionResult> OnGetAsync(string postId)
        {
            if (postId == null)
            {
                return NotFound();
            }

            Post = await _repository.Get(postId);

            if (Post == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
