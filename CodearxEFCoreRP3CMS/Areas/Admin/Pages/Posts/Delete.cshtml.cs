using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CodearxEFCoreRP3CMS.Data;
using CodearxEFCoreRP3CMS.Models;
using Microsoft.AspNetCore.Authorization;

namespace CodearxEFCoreRP3CMS.Areas.Admin.Pages.Posts
{
    [Authorize(Roles = "admin, editor")]
    public class DeleteModel : PageModel
    {
        private readonly IPostRepository _repository;

        public DeleteModel(IPostRepository repository)
        {
            _repository = repository;
        }

        public Post Post { get; set; }

        // URL: {domain}/admin/posts/delete/get-to-delete
        public async Task<IActionResult> OnGetAsync(string postId)
        {
            if (postId == null)
            {
                return NotFound();
            }

            Post = await _repository.GetAsync(postId);

            if (Post == null)
            {
                return NotFound();
            }

            return Page();
        }

        // URL: {domain}/admin/posts/delete/post-to-delete
        public async Task<IActionResult> OnPostAsync(string postId)
        {
            if (postId == null)
            {
                return NotFound();
            }            

            try
            {
                await _repository.DeleteAsync(postId);

                return RedirectToPage("./Index");
            }
            catch (KeyNotFoundException /*ex*/)
            {
                return NotFound();
            }
        }
    }
}
