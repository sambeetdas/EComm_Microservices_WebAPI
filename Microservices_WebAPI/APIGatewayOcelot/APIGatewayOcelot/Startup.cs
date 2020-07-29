using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ocelot.Middleware;
using Ocelot.DependencyInjection;
using Auth.JWT;
using APIGatewayOcelot.AuthHandler;

namespace APIGatewayOcelot
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Added for Auth.JWT
            services.AddAuthService();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "CustomAuth";
                //options.DefaultAuthenticateScheme = "CustomScheme";
                //options.DefaultChallengeScheme = "CustomScheme";
            })
           .AddCustomAuth("CustomAuth", o => { });

            services.AddOcelot(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOcelot();
        }
    }
}
