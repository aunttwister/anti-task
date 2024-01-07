using AntiToDo.Security.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Security.Common.Interfaces
{
    public interface ISecurityDbContext
    {
        public DbSet<LoginDetails> LoginDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AuthenticationAudit> AuthenticationAudits { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        void ClearTracker();
        void UpdateEntityState<T>(T entity, EntityState modified) where T : class;
    }
}
