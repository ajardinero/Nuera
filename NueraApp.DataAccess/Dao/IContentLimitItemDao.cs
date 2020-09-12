using System.Collections.Generic;
using NueraApp.Domain.Models;

namespace NueraApp.DataAccess.Dao
{
    public interface IContentLimitItemDao
    {
        IList<ContentLimitItem> GetItemsBy(int categoryId);
        void Add(ContentLimitItem item);
        void Delete(int id);        
    }
}
