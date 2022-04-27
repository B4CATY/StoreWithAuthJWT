using API1.Models;
using API1.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API1.Repository.OrderRepository
{
    public interface IOrderRepository
    {
        Task<List<OrderEntityViewModel>> GetOrdersAsync(string email);
        Task<List<ReturnByIdOrderViewModel>> GetOrderByIdAsync(string email, int orderId);
        Task CreateOrderAsync(CreateOrderViewModel model);
    }
}
