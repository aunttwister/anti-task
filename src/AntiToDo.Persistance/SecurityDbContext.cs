using AntiToDo.Application.Common.Interfaces.IDbContexts;
using AntiToDo.Application.Common.Interfaces;
using AntiToDo.Domain;
using AntiToDo.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntiToDo.Persistance.Configurations.SecurityConfiguration;
using AntiToDo.Security.Common.Interfaces;
using AntiToDo.Security.Domain;

namespace AntiToDo.Persistance
{
    public class SecurityDbContext : DbContextExtend, ISecurityDbContext
    {
        public SecurityDbContext(DbContextOptions<AntiToDoDbContext> options) : base(options) { }

        public SecurityDbContext(DbContextOptions<AntiToDoDbContext> options,
            IDateTime datetime,
            ICurrentUserService userService) : base(options, datetime, userService) { }
        public DbSet<LoginDetails> LoginDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AuthenticationAudit> AuthenticationAudits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new LoginDetailsConfiguration());
        }
    }
}
