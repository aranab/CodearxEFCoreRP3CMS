using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodearxEFCoreRP3CMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodearxEFCoreRP3CMS.Areas.Admin.Pages.Tags
{
    public class EditModel : PageModel
    {
        private readonly ITagRepository _repository;

        public EditModel(ITagRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public string Tag { get; set; }

        // URL: {domain}/admin/tag/edit/tag-to-edit
        public async Task<ActionResult> OnGetAsync(string tag)
        {
            if (!await _repository.Exists(tag))
            {
                return NotFound();
            }

            Tag = tag;

            return Page();
        }

        // URL: {domain}/admin/tag/edit/tag-to-edit
        public async Task<ActionResult> OnPostAsync(string oldTag)
        {
            var tags = await _repository.GetAll();

            if (!tags.Contains(oldTag))
            {
                return NotFound();
            }

            if (tags.Contains(Tag))
            {
                return RedirectToPage("./Index");
            }

            if (string.IsNullOrWhiteSpace(Tag))
            {
                ModelState.AddModelError("key", "New tag value cannot be empty.");

                Tag = oldTag;

                return Page();
            }

            await _repository.Edit(oldTag, Tag);

            return RedirectToPage("./Index");
        }
    }
}
