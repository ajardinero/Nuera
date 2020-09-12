using Moq;
using NueraApp.DataAccess.Dao;
using NueraApp.Domain.Models;
using NueraApp.Service.Services;
using NUnit.Framework;

namespace NueraApp.Test.Service.Services
{
    [TestFixture]
    public class InsuranceServiceTests
    {
        private Mock<IContentLimitCategoryDao> _mockContentLimitCategoryDao;
        private Mock<IContentLimitItemDao> _mockContentLimitItemsDao;
        private IInsuranceService _sut;

        [SetUp]
        public void Setup()
        {
            _mockContentLimitCategoryDao = new Mock<IContentLimitCategoryDao>();
            _mockContentLimitItemsDao = new Mock<IContentLimitItemDao>();
            _sut = new InsuranceService(_mockContentLimitCategoryDao.Object, _mockContentLimitItemsDao.Object);
        }

        [Test]
        public void Should_Add_Content_Limit_Item()
        {
            //SETUP
            int categoryId = 1;
            ContentLimitItem item = new ContentLimitItem() { Name = "TestName", Value = 100, ContentLimitCategoryId = categoryId };
            ContentLimitCategory category = new ContentLimitCategory() { CategoryName = "TestCategory", Id = categoryId };
            _mockContentLimitCategoryDao.Setup(m => m.Get(It.Is<int>(id => id == categoryId))).Returns(category);

            //TEST
            _sut.AddContentLimitItem(item);

            //VERIFY
            _mockContentLimitItemsDao.Verify(m => m.Add(It.IsAny<ContentLimitItem>()), Times.Once);
        }

        [Test]
        public void Should_Delete_Content_Limit_Item()
        {
            //SETUP
            int itemId = 1;

            //TEST
            _sut.DeleteContentLimitItem(itemId);

            //VERIFY
            _mockContentLimitItemsDao.Verify(m => m.Delete(It.Is<int>( id => id == itemId)), Times.Once);
        }

        [Test]
        public void Should_Get_Content_Limit_Item_By_CategoryId()
        {
            //SETUP
            int categoryId = 1;
            
            //TEST
            _sut.GetContentLimitItemsBy(categoryId);

            //VERIFY
            _mockContentLimitItemsDao.Verify(m => m.GetItemsBy(It.Is<int>(id => id == categoryId)), Times.Once);
        }

        [Test]
        public void Should_Get_All_Categories()
        {
            //TEST
            _sut.GetCategories();

            //VERIFY
            _mockContentLimitCategoryDao.Verify(m => m.GetAll(), Times.Once);
        }
    }
}