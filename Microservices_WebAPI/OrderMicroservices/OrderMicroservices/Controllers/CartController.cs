using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using ServiceManager.IManager;

namespace OrderMicroservices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICart _cartManager;
        public CartController(ICart cartManager)
        {
            this._cartManager = cartManager;
        }

        [Route("processcart")]
        [HttpPost]
        public IActionResult ProcessCart([FromBody]CartModel cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            dynamic result = _cartManager.ProcessCart(cart);
            return Ok(result);
        }

        [Route("clearcart/{userId}")]
        [HttpDelete]
        public IActionResult ClearCart(Guid userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            dynamic result = _cartManager.ClearCart(userId);
            return Ok(result);
        }

        [Route("deletecart/{userId}/{productId}")]
        [HttpDelete]
        public IActionResult DeleteCart(Guid userId, Guid productId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            dynamic result = _cartManager.DeleteCart(userId,productId);
            return Ok(result);
        }

        [Route("getcartforuser/{userId}")]
        [HttpGet]
        public IActionResult GetCartForUser(Guid userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            dynamic result = _cartManager.GetCartForUser(userId);
            return Ok(result);
        }
    }
}