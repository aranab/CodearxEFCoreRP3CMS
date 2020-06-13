using CodearxEFCoreRP3CMS.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Areas.Admin.Pages.Tags
{
    public class IndexModel : PageModel
    {
        private readonly ITagRepository _repository;

        public IndexModel(ITagRepository repository)
        {
            _repository = repository;
        }

        public IList<string> Tags { get; set; }

        // URL: {domain}/admin/tag
        public async Task<IActionResult> OnGetAsync()
        {
            Tags = await _repository.GetAll();

            var selectedHeader = Request.Headers.GetCommaSeparatedValues("Accept");
            var isJsonRequest = selectedHeader.Contains("application/json");

            if (isJsonRequest)
            {
                return new JsonResult(Tags);
            }

            if (User.IsInRole("author"))
            {
                return Unauthorized();
            }

            return Page();
        }
    }
}
