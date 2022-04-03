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
    public class GeoController : ControllerBase
    {
        private readonly IGeoConfig _geoConfig;
        public GeoController(IGeoConfig geoConfig)
        {
            _geoConfig = geoConfig;
        }



        [HttpGet("getgeolocation")]
        public IActionResult GetGeolocation()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            dynamic result = _geoConfig.GetGeolocation();
            return Ok(result);
        }
    }
}