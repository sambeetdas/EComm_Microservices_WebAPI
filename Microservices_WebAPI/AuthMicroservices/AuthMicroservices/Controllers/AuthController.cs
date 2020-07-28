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

namespace AuthMicroservices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;
        private readonly JWTModule _module;
        private readonly TokenRequestModel _reqModel;
        public AuthController(IAuthRepository authRepository, JWTModule module, TokenRequestModel reqModel, IConfiguration configuration)
        {
            this._authRepository = authRepository;
            this._configuration = configuration;
            this._module = module;
            this._reqModel = reqModel;
        }



        [HttpPost("createtoken")]
        public IActionResult CreateToken([FromBody]AuthModel auth)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }

            dynamic tokenResult = null;
            if (_authRepository.ValidateUser(auth))
            {
                string secrect = _configuration.GetSection("AuthJWT").GetSection("Secrect").Value;

                _reqModel.Issuer = "authjwt_team";
                _reqModel.ExpiryInSeconds = "18000";
                //Below fuction would create the token.
                tokenResult = _module.CreateToken(_reqModel, secrect, AlgorithmType.SHA256);
            }

            return Ok(tokenResult);
        }
    }
}