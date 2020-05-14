using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Data
{
    public class TagRepository : ITagRepository
    {
        private readonly CMSContext _context;

        public TagRepository(CMSContext context)
        {
            _context = context;
        }

        public async Task<IList<string>> GetAll()
        {
            var tagsCollection = await _context.Posts
                .Select(p => p.CombinedTags)
                .AsNoTracking()
                .ToListAsync();

            return string.Join(',', tagsCollection).Split(',').Distinct().ToList();
        }

        public async Task<string> Get(string tag)
        {
            var posts = await _context.Posts
                .Where(p => p.CombinedTags.Contains(tag))
                .ToListAsync();

            posts = posts
                .Where(p => p.Tags.Contains(tag, StringComparer.CurrentCultureIgnoreCase))
                .ToList();

            if (posts == null)
            {
                throw new KeyNotFoundException($"The tag {tag} does not exist.");
            }

            return tag.ToLower();
        }

        public async Task Edit(string existingTag, string newTag)
        {
            var posts = await _context.Posts
                .Where(p => p.CombinedTags.Contains(existingTag))
                .ToListAsync();

            posts = posts
                .Where(p => p.Tags.Contains(existingTag, StringComparer.CurrentCultureIgnoreCase))
                .ToList();

            if (posts == null)
            {
                throw new KeyNotFoundException($"The tag {existingTag} does not exist.");
            }

            foreach (var post in posts)
            {
                post.Tags.Remove(existingTag);
                post.Tags.Add(newTag);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(string tag)
        {
            var posts = await _context.Posts
                .Where(p => p.CombinedTags.Contains(tag))
                .ToListAsync();

            posts = posts
                .Where(p => p.Tags.Contains(tag, StringComparer.CurrentCultureIgnoreCase))
                .ToList();

            if (posts == null)
            {
                throw new KeyNotFoundException($"The tag {tag} does not exist.");
            }

            foreach (var post in posts)
            {
                post.Tags.Remove(tag);
            }

            await _context.SaveChangesAsync();
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
