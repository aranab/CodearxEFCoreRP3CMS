using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CodearxEFCoreRP3CMS.Data;
using CodearxEFCoreRP3CMS.Models;
using CodearxEFCoreRP3CMS.Models.ModelBinders;

namespace CodearxEFCoreRP3CMS.Areas.Admin.Pages.Posts
{
    public class CreateModel : PageModel
    {
        private readonly IPostRepository _repository;

        public CreateModel(IPostRepository repository)
        {
            _repository = repository;
        }

        // URL: {domain}/admin/post/create
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Post Post { get; set; }

        // URL: {domain}/admin/post/create
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (string.IsNullOrWhiteSpace(Post.ID))
            {
                Post.ID = Post.Title;
            }

            Post.ID = Post.ID.MakeUrlFriendly();
            Post.Tags = Post.Tags.Select(tag => tag.MakeUrlFriendly()).ToList();

            try
            {
                await _repository.Create(Post);

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("key", ex.Message);

                return Page();
            }
        }
    }
}
