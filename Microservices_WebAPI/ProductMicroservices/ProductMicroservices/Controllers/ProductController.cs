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
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }


        [Route("processproduct")]
        [HttpPost]
        public IActionResult ProcessProduct([FromBody]ProductModel product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            dynamic result = _productRepository.ProcessProduct(product);
            return Ok(result);
        }


        [HttpGet("getproductbysku/{sku}")]
        public IActionResult GetProductBySku(string sku)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            dynamic result = _productRepository.GetProductBySku(sku);
            return Ok(result);
        }
    }
}