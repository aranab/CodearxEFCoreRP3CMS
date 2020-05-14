using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodearxEFCoreRP3CMS.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodearxEFCoreRP3CMS.Areas.Admin.Pages.Tags
{
    [Authorize(Roles = "admin, editor")]
    public class IndexModel : PageModel
    {
        private readonly ITagRepository _repository;

        public IndexModel(ITagRepository repository)
        {
            _repository = repository;
        }

        public IList<string> Tags { get; set; }

        // URL: {domain}/admin/tag
        public async Task OnGetAsync()
        {
            Tags = await _repository.GetAll();
        }
    }
}
