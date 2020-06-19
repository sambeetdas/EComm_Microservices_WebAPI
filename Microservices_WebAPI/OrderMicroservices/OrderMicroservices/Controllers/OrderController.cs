using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace UserMicroservices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }


        [HttpGet("getordersforuser/{userId}")]
        public IActionResult GetOrdersForUser(Guid userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            dynamic result = _orderRepository.GetOrderForUser(userId);
            return Ok(result);
        }
    }
}