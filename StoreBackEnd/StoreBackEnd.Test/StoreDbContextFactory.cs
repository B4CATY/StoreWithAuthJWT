using API1.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace StoreBackEnd.Test
{
    public class StoreDbContextFactory
    {
        public static int Id { get; set; } = 1000;

        public static StoreDbContext Create()
        {
            var options = new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new StoreDbContext(options);
            return context;
        }
    }
}
