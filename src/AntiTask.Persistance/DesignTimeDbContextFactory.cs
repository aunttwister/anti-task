using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AntiTask.Persistance
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AntiTaskDbContext>
    {
        AntiTaskDbContext IDesignTimeDbContextFactory<AntiTaskDbContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../AntiTask.Api/appsettings.Development.json").Build();
            var builder = new DbContextOptionsBuilder<AntiTaskDbContext>();
            var connectionString = configuration.GetConnectionString("ReservationDb");
            builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return new AntiTaskDbContext(builder.Options);
        }
    }
}
