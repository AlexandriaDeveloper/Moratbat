using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Application.Common;
using Application.Common.Messaging;
using Application.Services;

namespace Application.Extensions
{
    public static class AddApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddMediatR(config =>
              {
                  config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
              });
            services.AddScoped<INPOIService, NPOIService>();

            services.AddDbContext<AppDataContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });



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

            return services;
        }
    }
}