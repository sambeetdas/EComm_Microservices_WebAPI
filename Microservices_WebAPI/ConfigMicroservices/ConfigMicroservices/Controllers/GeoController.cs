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
    public class GeoController : ControllerBase
    {
        private readonly IGeoRepository _geoRepository;
        public GeoController(IGeoRepository geoRepository)
        {
            this._geoRepository = geoRepository;
        }



        [HttpGet("getgeolocation")]
        public IActionResult GetGeolocation()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            dynamic result = _geoRepository.GetGeoLocation();
            return Ok(result);
        }
    }
}