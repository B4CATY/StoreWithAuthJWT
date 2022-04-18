using API1.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API1.ViewModels;
using API1.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using API1.Repository.OrderRepository;

namespace API1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            CreateOrderViewModel model = new CreateOrderViewModel { 
                Id = 2,
                IdVideoCart = new int[] { 4, 2, 6, 11 },
                CountVideoCart = new int[] { 1, 2, 2, 1 },
            };  
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var orders = await _orderRepository.GetOrders(id);
            return Ok(orders);
        }

        [HttpPost]
        [Route("create")]
        public async Task <IActionResult> CreateOrder(CreateOrderViewModel model)
        {
            bool isSucces = await _orderRepository.Create(model);
            if (!isSucces) 
                return BadRequest();

            return Ok();
        }
    }
}
