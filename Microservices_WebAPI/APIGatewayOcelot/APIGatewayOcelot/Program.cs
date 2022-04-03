using APIGatewayOcelot.AuthHandler;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("ocelot.json")
                            .Build();

#region Add Services
//Added for Auth.JWT
//builder.Services.AddAuthService();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "CustomAuth";
    //options.DefaultAuthenticateScheme = "CustomScheme";
    //options.DefaultChallengeScheme = "CustomScheme";
}).AddCustomAuth("CustomAuth", o => { });

builder.Services.AddOcelot(configuration);

#endregion


var app = builder.Build();

app.UseOcelot();

app.Run();
