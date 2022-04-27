/*using API1.Data;
using API1.Repository.OrderRepository;
using API1.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StoreBackEnd.Test
{
    public class OrderRepositoryTest
    {
        private readonly StoreDbContext _dbContext;
        private readonly int _idMaxVideoCartInDb;
        private readonly int _idLastUserInDb;
        public OrderRepositoryTest()
        {
            _dbContext = StoreDbContextFactory.Create();
            _idMaxVideoCartInDb = _dbContext.Videocarts.Max(x => x.Id);
            _idLastUserInDb = _dbContext.Users.Max(x => x.Id);
        }
        *//*DbUpdateException*//*
        [Fact]
        public async Task CreateOrder_SelectedVideoCartsByIdWillNotExistInTheDb_ExceptionDbUpdateException()
        {
            OrderRepository repository = new OrderRepository(_dbContext);

            CreateOrderViewModel model = new CreateOrderViewModel { 
                IdVideoCart = new int[] { 8,
                    162,
                    6,
                    13 },
                CountVideoCart = new int[] { 2,
                    1,
                    7,
                    5 },
                UserId = 2,
                };
            //Action = () => throw new Exception();
            DbUpdateException db = new DbUpdateException();
            var ex = await Assert.ThrowsAsync<DbUpdateException>( async () => await repository.Create(model));

            int i = 0;
            Assert.Equal(db.Message, ex.Message);

            *//*var ex = Record.Exception(createTestingMethod);

            Assert.NotNull(ex);
            Assert.IsType<Exception>(ex);*/
            /*try
            {
                repository.Create(model);
                Assert.True(false);
            }
            catch (Exception)
            {

                Assert.True(true);
            }*//*

            // _dbContext.Dispose();
        }
    }
}
*/