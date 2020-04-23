using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Models
{
    public class CmsUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
