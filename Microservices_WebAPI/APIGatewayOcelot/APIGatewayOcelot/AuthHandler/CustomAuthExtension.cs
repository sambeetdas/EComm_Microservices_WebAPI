using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGatewayOcelot.AuthHandler
{
    public static class CustomAuthExtension
    {
        public static AuthenticationBuilder AddCustomAuth(this AuthenticationBuilder builder, string authenticationScheme, Action<CustomAuthOptions> configureOptions)
        {
            // Add custom authentication scheme with custom options and custom handler
            return builder.AddScheme<CustomAuthOptions, CustomAuth>(authenticationScheme, configureOptions);
        }
    }
}
