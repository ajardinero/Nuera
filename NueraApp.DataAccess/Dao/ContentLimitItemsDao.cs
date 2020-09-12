using System.Collections.Generic;
using System.Linq;
using NueraApp.DataAccess.Data;
using NueraApp.Domain.Models;

namespace NueraApp.DataAccess.Dao
{
    public class ContentLimitItemsDao : IContentLimitItemsDao
    {
        private NueraAppDbContext _context;

        public ContentLimitItemsDao(NueraAppDbContext context)
        {
            _context = context;
        }

        public void Add(ContentLimitItem item)
        {
            _context.ContentLimitItem.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            ContentLimitItem item = new ContentLimitItem() { Id = id };
            _context.ContentLimitItem.Attach(item);
            _context.ContentLimitItem.Remove(item);
            _context.SaveChanges();
        }

        public IList<ContentLimitItem> GetItemsBy(int categoryId)
        {
            return _context.ContentLimitItem
                .Where(x => x.ContentLimitCategory.Id == categoryId)
                .ToList();
        }
    }
}
