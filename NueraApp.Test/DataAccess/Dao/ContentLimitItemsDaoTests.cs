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
        private Mock<DbSet<ContentLimitItem>> _contentLimitItemDbSet;
        private IContentLimitItemsDao _sut;

        [SetUp]
        public void Setup()
        {
            _fakeDbContext = new FakeDbContext();
            _sut = new ContentLimitItemsDao(_fakeDbContext);

            _contentLimitItemDbSet = new Mock<DbSet<ContentLimitItem>>();
            _fakeDbContext.ContentLimitItem = _contentLimitItemDbSet.Object;
        }

        [Test]
        public void Should_Add_Item()
        {
            //SETUP
            var contentLimitItem = new ContentLimitItem();

            //TEST
            _sut.Add(contentLimitItem);

            //VERIFY
            _contentLimitItemDbSet.Verify(c => c.Add(It.Is<ContentLimitItem>(c => c == contentLimitItem)), Times.Once);
        }

        [Test]
        public void Should_Delete_Item()
        {
            //SETUP
            int itemId = 1;

            //TEST
            _sut.Delete(itemId);

            //VERIFY
            _contentLimitItemDbSet.Verify(c => c.Attach(It.IsAny<ContentLimitItem>()), Times.Once);
            _contentLimitItemDbSet.Verify(c => c.Remove(It.IsAny<ContentLimitItem>()), Times.Once);
        }
    }
}
