using Auth.JWT;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace APIGatewayOcelot.AuthHandler
{
    public class CustomAuth : AuthenticationHandler<CustomAuthOptions>
    {
        private JWTModule _module;
        private ValidateModel _validateModel;
        public CustomAuth(IOptionsMonitor<CustomAuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
             : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync() 
        {
            _module = new JWTModule();
            _validateModel = new ValidateModel();

            var headerValue = Request.Headers["AuthJWT"];

            if (String.IsNullOrWhiteSpace(headerValue))
            {
                //Invalid Authorization header
                return Task.FromResult(AuthenticateResult.Fail("Cannot read authorization header."));
            }

           
            string secrect = "F4760D";
            var validateResult = _module.VerifyToken(headerValue, secrect);

            if (validateResult.Status.Trim().ToUpper() == "FAILED")
            {
                return Task.FromResult(AuthenticateResult.Fail(validateResult.Content));
            }

            var identities = new List<ClaimsIdentity> { new ClaimsIdentity("custom auth type") };
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identities), Options.Scheme);
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
