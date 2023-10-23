using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AntiTask.Application.Common.Interfaces;
using AntiTask.Security.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiTask.Persistance
{
    public static class PersistanceServiceExtensions
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            AddAntiTaskDbContext(services, configuration);
            AddSecurityDbContext(services, configuration);
        }

        private static void AddAntiTaskDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ReservationDb");

                services.AddDbContext<ReservationDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), mySqlOptions =>
                {
                    mySqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null
                    );
                })
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging());

            services.AddScoped<IReservationDbContext>(provider => provider.GetService<ReservationDbContext>());
        }
        private static void AddSecurityDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SecurityDb");

            services.AddDbContext<SecurityDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), mySqlOptions =>
            {
                mySqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null
                );
            })
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging());

            services.AddScoped<ISecurityDbContext>(provider => provider.GetService<SecurityDbContext>());
        }
    }
}
