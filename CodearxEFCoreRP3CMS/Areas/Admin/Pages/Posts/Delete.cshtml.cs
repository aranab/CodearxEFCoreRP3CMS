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
    public class DeleteModel : PageModel
    {
        private readonly IPostRepository _repository;

        public DeleteModel(IPostRepository repository)
        {
            _repository = repository;
        }

        public Post Post { get; set; }

        // URL: {domain}/admin/post/delete/get-to-delete
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

        // URL: {domain}/admin/post/delete/post-to-delete
        public async Task<IActionResult> OnPostAsync(string postId)
        {
            if (postId == null)
            {
                return NotFound();
            }            

            try
            {
                await _repository.Delete(postId);

                return RedirectToPage("./Index");
            }
            catch (KeyNotFoundException /*ex*/)
            {
                return NotFound();
            }
        }
    }
}
