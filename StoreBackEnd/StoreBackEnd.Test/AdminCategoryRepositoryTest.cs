using API1.Repository.AdminCategoryRepository;
using System;
using System.Threading.Tasks;
using Xunit;
using API1.Data;
using System.Linq;

namespace StoreBackEnd.Test
{
    public class AdminCategoryRepositoryTest
    {
        private readonly StoreDbContext _dbContext;
        private readonly int _idMaxCategoryInDb;
        public AdminCategoryRepositoryTest()
        {
            _dbContext = StoreDbContextFactory.Create();
            _idMaxCategoryInDb = _dbContext.Categories.Max(x => x.Id);
        }

        [Fact]
        public async Task CreateCategory_IfCorrrectName_True()
        { 

            AdminCategoryRepository repository = new AdminCategoryRepository(_dbContext);

            var isSuccesed = await repository.CreateCategoryAcync("NewCategory");

            _dbContext.Dispose();

            Assert.True(isSuccesed);
        }

        [Fact]
        public async Task CreateCategory_IfCategoryExist_False()
        {

            AdminCategoryRepository repository = new AdminCategoryRepository(_dbContext);

            var nameCategory = _dbContext.Categories.Find(_idMaxCategoryInDb).Name;

            var isSuccesed = await repository.CreateCategoryAcync(nameCategory);

            _dbContext.Dispose();

            Assert.False(isSuccesed);
        }

        [Fact]
        public async Task RemoveCategoryById_IfCorrectId_True()
        { 
            AdminCategoryRepository repository = new AdminCategoryRepository(_dbContext);


            var isSuccesed = await repository.RemoveCategoryByIdAcync(_idMaxCategoryInDb);

            _dbContext.Dispose();

            Assert.True(isSuccesed);

        }

        [Fact]
        public async Task RemoveCategoryById_IfIdDoesNotExist_False()
        {
            AdminCategoryRepository repository = new AdminCategoryRepository(_dbContext);

            var isSuccesed = await repository.RemoveCategoryByIdAcync(_idMaxCategoryInDb + 1);

            _dbContext.Dispose();

            Assert.False(isSuccesed);
        }
    }
}
