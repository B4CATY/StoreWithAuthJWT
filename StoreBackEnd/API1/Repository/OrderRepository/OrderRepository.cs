using API1.Data;
using API1.Models;
using API1.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Repository.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly VideoCardDbContext _context;
        public OrderRepository(VideoCardDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(CreateOrderViewModel model)
        {
            if (model.IdVideoCart.Length != model.CountVideoCart.Length 
                || model.IdVideoCart.Length == 0 
                || model.CountVideoCart.Length == 0)
                return false;

            List<Orders> createOrdersList = new List<Orders>();

            for (int i = 0; i < model.IdVideoCart.Length; i++)
            {
                Orders ordersUser = new Orders
                {
                    VideoCartId = model.IdVideoCart[i],
                    Quantity = model.CountVideoCart[i]
                };
                createOrdersList.Add(ordersUser);
            }

            Order order = new Order
            {
                UserId = model.Id,
                Orders = createOrdersList
            };
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return true;
        }

         public async Task<object> GetOrders(int id)
         {
            var request1 = await _context.Users.Where(u => u.Id == id).Include(x=>x.Orders).ThenInclude(x=>x.Orders).ThenInclude(x=>x.VideoCart).FirstOrDefaultAsync();
            return request1.Orders;
         }
    }
}
