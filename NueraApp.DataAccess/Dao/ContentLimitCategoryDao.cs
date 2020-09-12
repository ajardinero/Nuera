using System.Collections.Generic;
using System.Linq;
using NueraApp.DataAccess.Data;
using NueraApp.Domain.Models;

namespace NueraApp.DataAccess.Dao
{
    public class ContentLimitCategoryDao : IContentLimitCategoryDao
    {
        private NueraAppDbContext _context;

        public ContentLimitCategoryDao(NueraAppDbContext context)
        {
            _context = context;
        }

        public ContentLimitCategory Get(int categoryId)
        {
            return _context.ContentLimitCategory.Find(categoryId);
        }

        public IList<ContentLimitCategory> GetAll()
        {
            return _context.ContentLimitCategory.ToList();
        }
    }
}
