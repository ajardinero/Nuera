using Microsoft.EntityFrameworkCore;
using NueraApp.DataAccess.Data;

namespace NueraApp.Test.DataAccess.Fakes
{
    public class FakeDbContext : NueraAppDbContext
    {
        public FakeDbContext() 
            : base(
                    new DbContextOptionsBuilder<NueraAppDbContext>()
                        .UseInMemoryDatabase(databaseName: "testDatabase")
                        .Options
                  )
        {
        }
    }
}
