using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Ciudadano.Api
{
    public static class IdentityServerAuthentication
    {
        public static void AddIdentityServerAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddAuthentication("Bearer")
            //    .AddIdentityServerAuthentication(options =>
            //    {
            //        options.Authority = configuration["Authentication:IdentityServerHostSecureUrl"];
            //        options.RequireHttpsMetadata = false;
            //        options.ApiName = "CopaLecheAPI";
            //    });

            services.AddAuthentication("Bearer").AddJwtBearer("Bearer",
                options =>
                {
                    options.Authority = configuration["Authentication:Authority"];
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new
                        TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });
        }

        public static void AddPolicies(this IServiceCollection services, IConfiguration configuration)
        {
            var audience = configuration["Authentication:Scope"];
            services.AddAuthorization(options =>
                options.AddPolicy("AtiIdentityServer4Policy",
                    policy => policy.RequireClaim("scope", audience)));

            //services.AddAuthorization(options =>
            //    options.AddPolicy("Customer",
            //        policy => policy.RequireClaim("scope", "APICustomer")));
        }
    }
}
