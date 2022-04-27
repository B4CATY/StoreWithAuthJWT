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
using Microsoft.AspNetCore.Authorization;
using System;
using Microsoft.Data.SqlClient;

namespace API1.Controllers
{
    [Authorize]
    //[Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /*[HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            CreateOrderViewModel model = new CreateOrderViewModel
            {
                Email = "admin@gamil.com",
                IdVideoCart = new int[] { 4, 2, 6, 11 },
                CountVideoCart = new int[] { 1, 2, 2, 1 },
            };
            var orders = await _orderRepository.GetOrdersAsync("TheBestUser4@gmail.com");
            return Ok(orders);
        }
*/
        [HttpGet]
        [Route("orders")]
        public async Task<IActionResult> GetOrdersAsync([FromQuery] EmailViewModel model)
        {
            var orders = await _orderRepository.GetOrdersAsync(model.Email);
            return Ok(orders);
        }

        [HttpGet]
        [Route("order")]
        public async Task<IActionResult> GetOrderAcync([FromQuery]GetOrderViewModel model)
        {
            var orders = await _orderRepository.GetOrderByIdAsync(model.Email, model.OrderId);

            if(orders == null)
                return BadRequest();

            return Ok(orders);
        }
        //[AllowAnonymous]
        [HttpPost]
        [Route("[controller]/create")]
        public async Task <IActionResult> CreateOrderAsync(CreateOrderViewModel model)
        {
            /*try
            {*/
            if (model.IdVideoCart.Length != model.CountVideoCart.Length
            || model.IdVideoCart.Length == 0
            || model.CountVideoCart.Length == 0)
                return BadRequest();


            await _orderRepository.CreateOrderAsync(model);
            return Ok();
            /*}
            catch (DbUpdateException)
            {
                return NotFound();
            }
            *//*catch (SqlException)
            {
                return NotFound();
            }*//*
            catch (Exception ex)
            {
                ModelState.AddModelError("Exeption", ex.Message);
                return BadRequest();
            }*/



        }
    }
}
