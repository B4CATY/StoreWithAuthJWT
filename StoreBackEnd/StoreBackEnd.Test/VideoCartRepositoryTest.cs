using API1.Data;
using API1.Repository.VideoCartRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StoreBackEnd.Test
{
    public class VideoCartRepositoryTest
    {

        private readonly StoreDbContext _dbContext;
        private readonly int _idMaxInDb;
        public VideoCartRepositoryTest()
        {
            _dbContext = StoreDbContextFactory.Create();
            _idMaxInDb = _dbContext.Videocarts.Max(x => x.Id);
        }
        //[Fact]
        [Theory]
        [InlineData(1, 5)]
        [InlineData(2, 5)]
        [InlineData(3, 5)]
        [InlineData(4, 5)]
        [InlineData(5, 5)]
        public async Task GetAllVideoCartsAsync_VideoCartsIsNull_True(int value1, int value2)
        {
            var repository = new VideoCartRepository(_dbContext);

            var countVideocarts = await repository.GetCountVideoCartAsync();
            int countPages = countVideocarts % value1 == 0 ? countVideocarts / value1 : countVideocarts / value1 + 1;
            var videoCartsOnPage = await repository.GetAllVideoCartsAsync(value1, value2);
            _dbContext.Dispose();
            if (value1 > countPages)
                Assert.Empty(videoCartsOnPage);
           
            else
                Assert.NotNull(videoCartsOnPage);
        }

        [Fact]
        public async Task GetVideoCartById_IfVideoCartWithMaxIdFromBdAndServiceIsTheSame_EqualSucces()
        {
            var repository = new VideoCartRepository(_dbContext);

            var expectedVideoCart = await _dbContext.Videocarts.FindAsync(_idMaxInDb);
            var actualVideoCart = await repository.GetVideoCartByIdAcync(_idMaxInDb);
            _dbContext.Dispose();

            Assert.Equal(expectedVideoCart.NameProduct, actualVideoCart.Name);
        }
    }
}
