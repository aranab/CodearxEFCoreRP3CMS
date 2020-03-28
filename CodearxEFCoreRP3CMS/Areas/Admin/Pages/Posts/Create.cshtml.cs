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
            Post = new Post() { Tags = new List<string>() { "test-1", "test-2" } };
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

            // TODO: add model in data store
           await _repository.Create(Post);

            return RedirectToPage("./Index");
        }
    }
}
