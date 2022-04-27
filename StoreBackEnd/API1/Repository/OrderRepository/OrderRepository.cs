using API1.Data;
using API1.Models;
using API1.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Repository.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreDbContext _context;
        public OrderRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task CreateOrderAsync(CreateOrderViewModel model)
        {
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
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
            if (user == null)
            {
                user = new User { Email = model.Email };
            }
            Order order = new Order
            {
                User = user,
                Orders = createOrdersList
            };
            _context.Order.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ReturnByIdOrderViewModel>> GetOrderByIdAsync(string email, int orderId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
                return null;

            var order = await _context.Order
                .Where(u => u.Id == orderId && u.UserId ==user.Id)
                .Include(x => x.Orders)
                .ThenInclude(x => x.VideoCart)
                .ThenInclude(x=>x.Category)
                .FirstOrDefaultAsync();

            if (order == null) 
                return null;

            var orderList = order.Orders.Select(x=>
                new ReturnByIdOrderViewModel {
                    Category=x.VideoCart.Category.Name, 
                    Name = x.VideoCart.NameProduct,  
                    Price = x.VideoCart.Price,
                    Quantity = x.Quantity,
                    Img = x.VideoCart.Img,

                }).ToList();

            return orderList;
        }

        public async Task<List<OrderEntityViewModel>> GetOrdersAsync(string email)
         {
            //var request1 = await _context.Users.Where(u => u.Id == id).Include(x=>x.Orders).ThenInclude(x=>x.Orders).ThenInclude(x=>x.VideoCart).FirstOrDefaultAsync();
            var orders = await _context.Users
                .Where(u => u.Email == email)
                .Include(x => x.Orders)
                .ThenInclude(x => x.Orders)
                .FirstOrDefaultAsync();

            if (orders == null)
                return null;

            var orderList = orders.Orders.
                Select(x => 
                new OrderEntityViewModel { OrderId = x.Id, PurchaseDate = x.PurchaseDate.ToString() }
                ).ToList();

            return orderList;
         }
    }
}
