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
    public class IndexModel : PageModel
    {
        private readonly IPostRepository _repository;

        public IndexModel(IPostRepository repository)
        {
            _repository = repository;
        }

        public IList<Post> Posts { get; set; }

        // URL: {domain}/admin/post
        public async Task OnGetAsync()
        {
            Posts = await _repository.GetAll();
        }
    }
}
