using API1.Data;
using API1.Repository.CategoryRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StoreBackEnd.Test
{
    public class CategoryRepositoryTest
    {
        private readonly StoreDbContext _dbContext;
        private readonly int _idMaxInDb;
        public CategoryRepositoryTest()
        {
            _dbContext = StoreDbContextFactory.Create();
        }

        [Fact]
        public async Task GetCategories_IfAllCategoriesTheSameFromBdAndService_ResultSucces()
        {
            CategoryRepository repository = new CategoryRepository(_dbContext);

            var expectedCategories = await _dbContext.Categories.ToListAsync();
            var actualCategoies = await repository.GetAllCategoriesAsync();
            _dbContext.Dispose();

            Assert.Equal(expectedCategories, actualCategoies);
        }

    }
}
