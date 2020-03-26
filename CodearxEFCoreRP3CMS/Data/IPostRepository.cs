using CodearxEFCoreRP3CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Data
{
    public interface IPostRepository
    {
        Task<Post> Get(string id);
    }
}
