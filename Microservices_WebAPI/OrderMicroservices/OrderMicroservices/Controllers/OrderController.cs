using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using ServiceManager.IManager;

namespace UserMicroservices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _orderManager;
        public OrderController(IOrder orderManager)
        {
            _orderManager = orderManager;
        }


        [HttpGet("getordersforuser/{userId}")]
        public IActionResult GetOrdersForUser(Guid userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            dynamic result = _orderManager.GetOrdersForUser(userId);
            return Ok(result);
        }
    }
}