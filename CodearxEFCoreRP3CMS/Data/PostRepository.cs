using CodearxEFCoreRP3CMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Data
{
    public class PostRepository : IPostRepository
    {
        private readonly CMSContext _context;

        public PostRepository(CMSContext context)
        {
            _context = context;
        }

        public async Task<Post> GetAsync(string id)
        {
            return await _context.Posts
                .Include(p => p.Author)
                .FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<IList<Post>> GetAllAsync()
        {
            return await _context.Posts
                .Include(p => p.Author)
                .OrderByDescending(p => p.Created)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IList<Post>> GetPostsByAuthorAsync(string authorId)
        {
            return await _context.Posts
                .Include(p => p.Author)
                .Where(p => p.AuthorID == authorId)
                .OrderByDescending(p => p.Created)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task CreateAsync(Post model)
        {
            var post = await _context.Posts
                .FirstOrDefaultAsync(p => p.ID == model.ID);

            if (post != null)
            {
                throw new ArgumentException($"A post with the id of {model.ID} already exists.");
            }

            _context.Posts.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(string id, Post updatedItem)
        {
            var post = await _context.Posts
                .FirstOrDefaultAsync(p => p.ID == id);

            if (post == null)
            {
                throw new KeyNotFoundException($"The post with the id of {id} does not in the data store.");
            }

            post.ID = updatedItem.ID;
            post.Title = updatedItem.Title;
            post.Content = updatedItem.Content;
            post.Published = updatedItem.Published;
            post.Tags = updatedItem.Tags;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var post = await _context.Posts
                .FirstOrDefaultAsync(p => p.ID == id);

            if (post == null)
            {
                throw new KeyNotFoundException($"The post with the id of {id} does not exist.");
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Post>> GetPublishedPostsAsync()
        {
            return await _context.Posts
                .Include(p => p.Author)
                .Where(p => p.Published < DateTime.Now)
                .OrderByDescending(p => p.Published)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IList<Post>> GetPostsByTagAsync(string tagId)
        {
            var posts = await _context.Posts
                .Include(p => p.Author)
                .Where(p => p.CombinedTags.Contains(tagId))
                .ToListAsync();

            return posts
                .Where(p => p.Tags.Contains(tagId, StringComparer.CurrentCultureIgnoreCase))
                .ToList();
        }

        private bool _disposed = false;
        public void Dispose()
        {
            if (!_disposed)
            {
                _context.Dispose();
            }

            _disposed = true;
        }
    }
}
