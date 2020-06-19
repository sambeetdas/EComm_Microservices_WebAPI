using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace OrderMicroservices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            this._cartRepository = cartRepository;
        }

        [Route("processcart")]
        [HttpPost]
        public IActionResult ProcessCart([FromBody]CartModel cart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            dynamic result = _cartRepository.ProcessCart(cart);
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

            dynamic result = _cartRepository.ClearCart(userId);
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

            dynamic result = _cartRepository.DeleteCart(userId,productId);
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

            dynamic result = _cartRepository.GetCartForUser(userId);
            return Ok(result);
        }
    }
}