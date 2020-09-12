using Microsoft.EntityFrameworkCore;
using Moq;
using NueraApp.DataAccess.Dao;
using NueraApp.Domain.Models;
using NueraApp.Test.DataAccess.Fakes;
using NUnit.Framework;

namespace NueraApp.Test.DataAccess.Dao
{
    [TestFixture]
    public class ContentLimitItemsDaoTests
    {
        private FakeDbContext _fakeDbContext;
        private Mock<DbSet<ContentLimitItem>> _mockContentLimitItemDbSet;
        private IContentLimitItemDao _sut;

        [SetUp]
        public void Setup()
        {
            _fakeDbContext = new FakeDbContext();
            _sut = new ContentLimitItemDao(_fakeDbContext);

            _mockContentLimitItemDbSet = new Mock<DbSet<ContentLimitItem>>();
            _fakeDbContext.ContentLimitItem = _mockContentLimitItemDbSet.Object;
        }

        [Test]
        public void Should_Add_Item()
        {
            //SETUP
            var contentLimitItem = new ContentLimitItem();

            //TEST
            _sut.Add(contentLimitItem);

            //VERIFY
            _mockContentLimitItemDbSet.Verify(c => c.Add(It.Is<ContentLimitItem>(c => c == contentLimitItem)), Times.Once);
        }

        [Test]
        public void Should_Delete_Item()
        {
            //SETUP
            int itemId = 1;

            //TEST
            _sut.Delete(itemId);

            //VERIFY
            _mockContentLimitItemDbSet.Verify(c => c.Attach(It.IsAny<ContentLimitItem>()), Times.Once);
            _mockContentLimitItemDbSet.Verify(c => c.Remove(It.IsAny<ContentLimitItem>()), Times.Once);
        }
    }
}
