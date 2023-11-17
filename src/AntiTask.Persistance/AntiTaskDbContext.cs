using AntiTask.Application.Common.Interfaces;
using AntiTask.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AntiTask.Persistance
{
    public class AntiTaskDbContext : DbContextExtend, IAntiTaskDbContext
    {
        public AntiTaskDbContext(DbContextOptions<AntiTaskDbContext> options) : base(options) { }

        public AntiTaskDbContext(DbContextOptions<AntiTaskDbContext> options,
            IDateTime datetime,
            ICurrentUserService userService) : base(options, datetime, userService) { }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TaskConfiguration());
        }
    }
}
