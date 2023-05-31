
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using Domain.IdentityModels;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Persistence.Services;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration config)
        {


            services.AddCors(opt =>
            {

                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithExposedHeaders("WWW-Authenticate")
                    .WithOrigins("http://localhost:4200");
                });
            });
            ;

            services.Configure<JWT>(config.GetSection("JWT"));
            services.AddIdentityCore<AppUser>(opt =>
            {

                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;

            })
             .AddRoles<IdentityRole>()
             .AddSignInManager<SignInManager<AppUser>>()
            .AddEntityFrameworkStores<AppDataContext>();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]));

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

            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<TokenService>(s => new TokenService(config));
            return services;
        }

    }
}