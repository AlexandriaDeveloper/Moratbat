
using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Constants;
using Persistence.Repositories;

namespace Persistence
{
    public static class AddPersistenceServiceExtension
    {
        public static IServiceCollection AddPersistencService(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<AppDataContext>(opt =>
        {
            opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            //   opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

            //services.AddScoped<IPaginationInfo, PaginationInfo>();
            // services.AddScoped<IParam, Param>();
            services.AddScoped<IUOW, UOW>();
            //<IHttpContextAccessor, HttpContextAccessor>();

            // services.AddHttpContextAccessor();


            return services;
        }

    }
}