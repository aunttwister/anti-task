using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiTask.Application.Common.Interfaces
{
    public interface IAntiTaskDbContext
    {
        public DbSet<Task> Tasks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void ClearTracker();
        void UpdateEntityState<T>(T entity, EntityState modified) where T : class;
    }
}
