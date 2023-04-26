using System.Reflection;
using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Helper;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using Domain.IdentityModels;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration config)
        {

            services.Configure<JWT>(config.GetSection("JWT"));
            services.AddIdentityCore<AppUser>(opt =>
            {

                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;

            })
             .AddRoles<IdentityRole>()
             .AddSignInManager<SignInManager<AppUser>>()
            .AddEntityFrameworkStores<AppDataContext>()

           ;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(s: config["JWT:Key"]));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.SaveToken = false;
                    opt.RequireHttpsMetadata = false;
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateIssuer = true,
                        ValidIssuer = config["JWT:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = config["JWT:Audience"],
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };

                }).AddCookie();

            // services.AddAuthorization();


            services.AddScoped<TokenService>(s => new TokenService(config));
            return services;
        }

    }
}