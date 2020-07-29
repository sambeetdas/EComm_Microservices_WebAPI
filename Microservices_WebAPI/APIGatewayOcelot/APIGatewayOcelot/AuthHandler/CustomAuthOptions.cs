using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGatewayOcelot.AuthHandler
{
    public class CustomAuthOptions : AuthenticationSchemeOptions
    {
        public const string CustomAuth = "CustomAuth";
        public string Scheme => CustomAuth;
        public string Secrect { get; set; }
    }
}
