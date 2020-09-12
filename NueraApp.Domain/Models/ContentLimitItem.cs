using System.ComponentModel.DataAnnotations.Schema;

namespace NueraApp.Domain.Models
{
    public class ContentLimitItem : AuditEntity
    {
        public string Name { get; set; }
        [Column(TypeName = "decimal(12, 2)")]
        public decimal Value { get; set; }
        public int ContentLimitCategoryId { get; set; }
        public ContentLimitCategory ContentLimitCategory { get; set; }
    }
}
