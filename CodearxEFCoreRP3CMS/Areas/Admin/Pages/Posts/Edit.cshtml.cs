using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodearxEFCoreRP3CMS.Data;
using CodearxEFCoreRP3CMS.Models;

namespace CodearxEFCoreRP3CMS.Areas.Admin.Pages.Posts
{
    public class EditModel : PageModel
    {
        private readonly IPostRepository _repository;

        public EditModel(IPostRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public Post Post { get; set; }

        // URL: {domain}/admin/post/edit/post-to-edit
        public async Task<IActionResult> OnGetAsync(string postId)
        {
            if (postId == null)
            {
                return NotFound();
            }

            // TODO: to retrieve the model from the data store
            Post = await _repository.Get(postId);

            if (Post == null)
            {
                return NotFound();
            }

            return Page();
        }

        // URL: {domain}/admin/post/edit/post-to-edit
        public async Task<IActionResult> OnPostAsync(string postId)
        {
            if (postId == null)
            {
                return NotFound();
            }

            var postToUpdate = await _repository.Get(postId);

            if (postToUpdate == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // TODO: update model in data store
            await _repository.Edit(postId, Post);

            return RedirectToPage("./Index");
        }
    }
}
