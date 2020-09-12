using Microsoft.EntityFrameworkCore;

namespace NueraApp.DataAccess.Data
{
    public class NueraAppDbContext : DbContext
    {
        public NueraAppDbContext(DbContextOptions<NueraAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<NueraApp.Domain.Models.ContentLimitCategory> ContentLimitCategory { get; set; }

        public DbSet<NueraApp.Domain.Models.ContentLimitItem> ContentLimitItem { get; set; }
    }
}
