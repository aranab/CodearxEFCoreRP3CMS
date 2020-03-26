using CodearxEFCoreRP3CMS.Models;
using Microsoft.EntityFrameworkCore;

namespace CodearxEFCoreRP3CMS.Data
{
    public class CMSContext : DbContext
    {
        public CMSContext(DbContextOptions<CMSContext> options) : base(options)
        { }

        public DbSet<Post> Posts { get; set; }
    }
}
