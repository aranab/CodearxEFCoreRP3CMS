using CodearxEFCoreRP3CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Data
{
    public class PostRepository : IPostRepository
    {
        public Task Create(Post post)
        {
            throw new NotImplementedException();
        }

        public Task Edit(string postId, Post post)
        {
            throw new NotImplementedException();
        }

        public Task<Post> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Post>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
