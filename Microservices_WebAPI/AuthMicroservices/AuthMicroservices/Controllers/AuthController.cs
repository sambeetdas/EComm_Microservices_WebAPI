using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.JWT;
using Auth.JWT.Common;
using Auth.JWT.Model;
using DataAccess.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;
using ServiceManager.IManager;

namespace AuthMicroservices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AuthController(IAuthManager authManager)
        {
            _authManager = authManager;
        }



        [HttpPost("createtoken")]
        public IActionResult CreateToken([FromBody]AuthModel auth)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            var tokenResult = _authManager.CreateToken(auth);

            return Ok(tokenResult);
        }
    }
}