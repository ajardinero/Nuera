using Microsoft.EntityFrameworkCore;
using Moq;
using NueraApp.DataAccess.Dao;
using NueraApp.Domain.Models;
using NueraApp.Test.DataAccess.Fakes;
using NUnit.Framework;

namespace NueraApp.Test.DataAccess.Dao
{
    [TestFixture]
    public class ContentLimitCategoriesDaoTests
    {
        private FakeDbContext _fakeDbContext;
        private Mock<DbSet<ContentLimitCategory>> _mockContentLimitCategoryDbSet;
        private IContentLimitCategoryDao _sut;

        [SetUp]
        public void Setup()
        {
            _fakeDbContext = new FakeDbContext();
            _sut = new ContentLimitCategoryDao(_fakeDbContext);

            _mockContentLimitCategoryDbSet = new Mock<DbSet<ContentLimitCategory>>();
            _fakeDbContext.ContentLimitCategory = _mockContentLimitCategoryDbSet.Object;
        }

        [Test]
        public void Should_Get_A_Category_Record()
        {
            //SETUP
            int categoryId = 1;

            //TEST
            _sut.Get(categoryId);

            //VERIFY
            _mockContentLimitCategoryDbSet.Verify(c => c.Find(It.Is<int>(id => id == categoryId)), Times.Once);
        }
    }
}
