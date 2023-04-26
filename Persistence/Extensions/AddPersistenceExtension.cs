
using Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence
{
    public static class AddPersistenceServiceExtension
    {
        public static IServiceCollection AddPersistencService(this IServiceCollection services)
        {

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUOW, UOW>();
            // services.AddHttpContextAccessor();


            return services;
        }

    }
}