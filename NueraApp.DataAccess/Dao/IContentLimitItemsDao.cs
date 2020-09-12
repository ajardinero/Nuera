﻿using System.Collections.Generic;
using NueraApp.Domain.Models;

namespace NueraApp.DataAccess.Dao
{
    public interface IContentLimitItemsDao
    {
        IList<ContentLimitItem> GetItemsBy(int categoryId);
        void Add(ContentLimitItem item);
        void Delete(int id);        
    }
}
