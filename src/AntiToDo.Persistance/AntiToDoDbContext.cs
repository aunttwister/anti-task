using AntiToDo.Application.Common.Interfaces;
using AntiToDo.Application.Common.Interfaces.IDbContexts;
using AntiToDo.Domain;
using AntiToDo.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AntiToDo.Persistance
{
    public class AntiToDoDbContext : DbContextExtend, IAntiToDoDbContext
    {
        public AntiToDoDbContext(DbContextOptions<AntiToDoDbContext> options) : base(options) { }

        public AntiToDoDbContext(DbContextOptions<AntiToDoDbContext> options,
            IDateTime datetime,
            ICurrentUserService userService) : base(options, datetime, userService) { }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<ToDoItemHierarchy> ToDoItemHierarchies { get; set; }
        public DbSet<Estimation> Estimations { get; set; }
        public DbSet<Priority> Priority { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ToDoItemConfiguration());
            modelBuilder.ApplyConfiguration(new ToDoItemHierarchyConfiguration());
            modelBuilder.ApplyConfiguration(new ToDoGroupConfiguration());
            modelBuilder.ApplyConfiguration(new ToDoGroupHierarchyConfiguration());
            modelBuilder.ApplyConfiguration(new PriorityConfiguration());
            modelBuilder.ApplyConfiguration(new EstimationConfiguration());
        }
    }
}
