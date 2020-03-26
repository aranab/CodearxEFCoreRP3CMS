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
        Task Edit(string postId, Post post);
        Task Create(Post post);
        Task<IList<Post>> GetAll();
    }
}
