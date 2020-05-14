using CodearxEFCoreRP3CMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Data
{
    public interface IPostRepository
    {
        Task<Post> GetAsync(string id);
        Task<IList<Post>> GetAllAsync();
        Task<IList<Post>> GetPostsByAuthorAsync(string authorId);
        Task CreateAsync(Post model);
        Task EditAsync(string id, Post updatedItem);
        Task DeleteAsync(string id);
    }
}
