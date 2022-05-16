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
    public static class JwtAuthentication
    {
        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var validIssuers = new List<string>()
            {
                configuration["Authentication:Jwt:SecureIssuer"],
                configuration["Authentication:Jwt:InsecureIssuer"]
            };

            var validAudiences = new List<string>()
            {
                configuration["Authentication:Jwt:SecureAudience"],
                configuration["Authentication:Jwt:InsecureAudience"]
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; //cristian
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //Capa para manejo de Tokens
            }).AddJwtBearer(options => 
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false, // TODO set to true on Production
                    ValidateAudience = false, // TODO set to true on Production
                    ValidateLifetime = false, //Cuando expira el token
                    ValidIssuers = validIssuers,
                    ValidAudiences = validAudiences,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:Jwt:SecretKey"]))
                };
            });
        }
    }
}
