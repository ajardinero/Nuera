using System.Collections.Generic;
using NueraApp.Domain.Models;

namespace NueraApp.DataAccess.Dao
{
    public interface IContentLimitCategoryDao
    {
        IList<ContentLimitCategory> GetAll();
        ContentLimitCategory Get(int categoryId);
    }
}
