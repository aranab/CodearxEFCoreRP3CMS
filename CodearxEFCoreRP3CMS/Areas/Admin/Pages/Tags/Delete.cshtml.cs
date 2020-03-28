using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodearxEFCoreRP3CMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodearxEFCoreRP3CMS.Areas.Admin.Pages.Tags
{
    public class DeleteModel : PageModel
    {
        private readonly ITagRepository _repository;

        public DeleteModel(ITagRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public string Tag { get; set; }

        // URL: {domain}/admin/tag/delete/tag-to-delete
        public async Task<ActionResult> OnGetAsync(string tag)
        {
            if (!await _repository.Exists(tag))
            {
                return NotFound();
            }

            Tag = tag;

            return Page();
        }

        // URL: {domain}/admin/tag/delete/tag-to-delete
        public async Task<ActionResult> OnPostAsync()
        {
            if (!await _repository.Exists(Tag))
            {
                return NotFound();
            }

            await _repository.Delete(Tag);

            return RedirectToPage("./Index");
        }
    }
}
