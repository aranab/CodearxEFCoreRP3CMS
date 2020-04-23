using CodearxEFCoreRP3CMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodearxEFCoreRP3CMS.Data
{
    public class CMSContext : IdentityDbContext<CmsUser>
    {
        public CMSContext(DbContextOptions<CMSContext> options) : base(options)
        { }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
