using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AntiToDo.Persistance
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AntiToDoDbContext>
    {
        AntiToDoDbContext IDesignTimeDbContextFactory<AntiToDoDbContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../AntiToDo.Api/appsettings.Development.json").Build();
            var builder = new DbContextOptionsBuilder<AntiToDoDbContext>();
            var connectionString = configuration.GetConnectionString("AntiToDoDb");
            builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            return new AntiToDoDbContext(builder.Options);
        }
    }
}
