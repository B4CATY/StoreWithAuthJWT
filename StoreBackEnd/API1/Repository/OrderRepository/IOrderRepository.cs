using API1.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API1.Repository.OrderRepository
{
    public interface IOrderRepository
    {
        Task<object> GetOrders(int id);
        Task<bool> Create(CreateOrderViewModel model);
    }
}
