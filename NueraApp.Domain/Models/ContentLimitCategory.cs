using System.Collections.Generic;

namespace NueraApp.Domain.Models
{
    public class ContentLimitCategory : AuditEntity
    {
        public string CategoryName { get; set; }
        public List<ContentLimitItem> Items { get; set; }
    }
}
