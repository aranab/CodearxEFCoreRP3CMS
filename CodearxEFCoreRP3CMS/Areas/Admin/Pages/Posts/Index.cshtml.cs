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
        private readonly CMSContext _context;

        public IndexModel(CMSContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get; set; }

        public async Task OnGetAsync()
        {
            Post = await _context.Posts.ToListAsync();
        }
    }
}
