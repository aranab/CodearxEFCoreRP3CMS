using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodearxEFCoreRP3CMS.Data
{
    public interface ITagRepository
    {
        Task<IList<string>> GetAll();
        Task<bool> Exists(string tag);
        Task Edit(string existingTag, string newTag);
        Task Delete(string tag);
    }
}
