using System.Collections.Generic;
using NueraApp.Domain.Models;

namespace NueraApp.Service.Services
{
    public interface IInsuranceService
    {
        IList<ContentLimitCategory> GetCategories();
        IList<ContentLimitItem> GetContentLimitItemsBy(int categoryId);
        int AddContentLimitItem(ContentLimitItem item);
        int DeleteContentLimitItem(int id);
    }
}
