using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Persistance
{
    public static class PersistanceServiceExtensions
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            AddAntiTaskDbContext(services, configuration);
        }

        private static void AddAntiTaskDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AntiTaskDb");
            ServerVersion serverVersion = ServerVersion.AutoDetect(connectionString);

                services.AddDbContext<AntiToDoDbContext>(options =>
                options.UseMySql(connectionString, serverVersion, mySqlOptions =>
                {
                    mySqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null
                    );
                })
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging());

            services.AddScoped(provider => provider.GetService<AntiToDoDbContext>());
        }
    }
}
