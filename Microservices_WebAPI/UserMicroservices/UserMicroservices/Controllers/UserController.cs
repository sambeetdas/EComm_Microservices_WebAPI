using DataAccess.IRepository;
using Microsoft.AspNetCore.Mvc;
using Model;
using ServiceManager.IManager;
using System;

namespace UserMicroservices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }


        [Route("processuser")]
        [HttpPost]
        public IActionResult ProcessUser([FromBody]UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            dynamic result = _user.ProcessUser(user);
            return Ok(result);
        }


        [HttpGet("getuserbyid/{userId}")]
        public IActionResult GetUserById(Guid userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            dynamic result = _user.GetUserById(userId);
            return Ok(result);
        }

        [HttpGet("getuserbyusername/{username}")]
        public IActionResult GetUserByUserName(string username)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            dynamic result = _user.GetUserByUserName(username);
            return Ok(result);
        }
    }
}