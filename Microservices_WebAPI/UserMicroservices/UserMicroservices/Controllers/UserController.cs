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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }


        [Route("processuser")]
        [HttpPost]
        public IActionResult ProcessUser([FromBody]UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            dynamic result = _userRepository.ProcessUser(user);
            return Ok(result);
        }


        [HttpGet("getuserbyid/{userId}")]
        public IActionResult GetUserById(Guid userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            dynamic result = _userRepository.GetUserById(userId);
            return Ok(result);
        }

        [HttpGet("getuserbyusername/{username}")]
        public IActionResult GetUserByUserName(string username)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            dynamic result = _userRepository.GetUserByUserName(username);
            return Ok(result);
        }
    }
}