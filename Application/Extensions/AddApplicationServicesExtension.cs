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
using Application.Features.Employees.Queries.GetEmployees;

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
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<INPOIService, NPOIService>();


            return services;
        }
    }
}