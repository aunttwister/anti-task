using AntiToDo.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Application.Common.Interfaces.IDbContexts
{
    public interface IAntiToDoDbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<ToDoItemHierarchy> ToDoItemHierarchies { get; set; }
        public DbSet<Estimation> Estimations { get; set; }
        public DbSet<Priority> Priority { get; set; }
        public DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void ClearTracker();
        void UpdateEntityState<T>(T entity, EntityState modified) where T : class;
    }
}
