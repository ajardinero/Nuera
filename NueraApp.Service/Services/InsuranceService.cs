using System.Collections.Generic;
using NueraApp.DataAccess.Dao;
using NueraApp.Domain.Models;

namespace NueraApp.Service.Services
{
    public class InsuranceService : IInsuranceService
    {
        private IContentLimitCategoryDao _contentLimitCategoryDao;
        private IContentLimitItemDao _contentLimitItemsDao;

        public InsuranceService(IContentLimitCategoryDao contentLimitCategoryDao, IContentLimitItemDao contentLimitItemsDao)
        {
            _contentLimitCategoryDao = contentLimitCategoryDao;
            _contentLimitItemsDao = contentLimitItemsDao;
        }

        public int AddContentLimitItem(ContentLimitItem item)
        {
            var category = _contentLimitCategoryDao.Get(item.ContentLimitCategoryId);
            item.ContentLimitCategory = category;
            _contentLimitItemsDao.Add(item);
            return item.Id;
        }

        public int DeleteContentLimitItem(int id)
        {
            _contentLimitItemsDao.Delete(id);
            return 1;
        }

        public IList<ContentLimitItem> GetContentLimitItemsBy(int categoryId)
        {
            return _contentLimitItemsDao.GetItemsBy(categoryId);
        }

        public IList<ContentLimitCategory> GetCategories()
        {
            return _contentLimitCategoryDao.GetAll();
        }        
    }
}
