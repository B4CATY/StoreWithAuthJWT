using API1.Repository.AdminVideoCartRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using API1.ViewModels;
using API1.Data;

namespace StoreBackEnd.Test
{
    public class AdminVideoCartRepositoryTest
    {
        private readonly StoreDbContext _dbContext;
        private readonly int _idMaxCategoryInDb;
        private readonly int _idMaxVideocartInDb;
        public AdminVideoCartRepositoryTest()
        {
            _dbContext = StoreDbContextFactory.Create();
            _idMaxCategoryInDb = _dbContext.Categories.Max(x => x.Id);
            _idMaxVideocartInDb = _dbContext.Videocarts.Max(x => x.Id);
        }

        [Fact]
        public async Task CreateVideoCart_CorrectEntity_True()
        {
            AdminVideoCartRepository repository = new AdminVideoCartRepository(_dbContext);

            bool isSuccesed = await repository.CreateVideoCartAcync(new CreateVideocartViewModel { Name = "NewVideoCart", Price = 5000, CategoryId = _idMaxCategoryInDb, Img=""});

            _dbContext.Dispose();
            Assert.True(isSuccesed);
        }

        [Fact]
        public async Task CreateVideoCart_TheNameOfTheVideoCardIsTheSame_False()
        {
            AdminVideoCartRepository repository = new AdminVideoCartRepository(_dbContext);
            var videocart = _dbContext.Videocarts.Find(_idMaxCategoryInDb);


            bool isSuccesed = await repository.CreateVideoCartAcync(new CreateVideocartViewModel { Name = videocart.NameProduct, Price = 5000, CategoryId = _idMaxCategoryInDb, Img = "" });

            _dbContext.Dispose();
            Assert.False(isSuccesed);
        }

        [Fact]
        public async Task CreateVideoCart_CategoryDoesNotExist_False()
        {
            AdminVideoCartRepository repository = new AdminVideoCartRepository(_dbContext);
            var videocart = _dbContext.Videocarts.Find(_idMaxCategoryInDb);


            bool isSuccesed = await repository.CreateVideoCartAcync(new CreateVideocartViewModel { Name = videocart.NameProduct, Price = 5000, CategoryId = _idMaxCategoryInDb+1, Img = "" });

            _dbContext.Dispose();
            Assert.False(isSuccesed);
        }

        [Fact]
        public async Task RemoveVideocartCart_CorrectId_True()
        {
            AdminVideoCartRepository repository = new AdminVideoCartRepository(_dbContext);
   
            bool isSuccesed = await repository.RemoveVideocartCartAcync(_idMaxVideocartInDb);

            _dbContext.Dispose();
            Assert.True(isSuccesed);
        }

        [Fact]
        public async Task RemoveVideocartCart_IdDoesNotExist_False()
        {
            AdminVideoCartRepository repository = new AdminVideoCartRepository(_dbContext);

            bool isSuccesed = await repository.RemoveVideocartCartAcync(_idMaxVideocartInDb + 1);

            _dbContext.Dispose();
            Assert.False(isSuccesed);
        }

       

        
    }
}
