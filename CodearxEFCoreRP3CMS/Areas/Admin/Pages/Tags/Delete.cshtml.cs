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
        public async Task<IActionResult> OnGetAsync(string tag)
        {
            try
            {
                Tag = await _repository.Get(tag);

                return Page();
            }
            catch (KeyNotFoundException /*ex*/)
            {
                return NotFound();
            }
        }

        // URL: {domain}/admin/tag/delete/tag-to-delete
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                await _repository.Delete(Tag);

                return RedirectToPage("./Index");
            }
            catch (KeyNotFoundException /*ex*/)
            {
                return NotFound();
            }
        }
    }
}
