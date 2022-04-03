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
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productManager;
        public ProductController(IProduct productManager)
        {
            _productManager = productManager;
        }


        [Route("processproduct")]
        [HttpPost]
        public IActionResult ProcessProduct([FromBody]ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            dynamic result = _productManager.ProcessProduct(product);
            return Ok(result);
        }


        [HttpGet("getproductbysku/{sku}")]
        public IActionResult GetProductBySku(string sku)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            dynamic result = _productManager.GetProductBySku(sku);
            return Ok(result);
        }
    }
}