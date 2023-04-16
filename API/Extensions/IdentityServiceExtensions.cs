using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Persistence;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentityCore<AppUser>(opt =>
            {

                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;

            })
             .AddRoles<IdentityRole>()
             .AddSignInManager<SignInManager<AppUser>>()
            .AddEntityFrameworkStores<AppDataContext>()

           ;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(s: config["TokenKey"]));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                  
                });

           // services.AddAuthorization();
            services.AddScoped<TokenService>(s => new TokenService( config));
            return services;
        }

    }
}