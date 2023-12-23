using AntiToDo.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Persistance.Configurations
{
    public class PriorityConfiguration : AuditableEntityConfiguration<Priority>
    {
        public override void ConfigureAuditableEntity(EntityTypeBuilder<Priority> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(p => p.Description)
                .HasMaxLength(255)
                .IsRequired(false);
            builder.HasMany(p => p.ToDoItems)
                .WithOne(tdi => tdi.Priority)
                .HasForeignKey(tdi => tdi.PriorityId)
                .IsRequired(false);
            builder.HasMany(p => p.ToDoGroups)
                .WithOne(tdg => tdg.Priority)
                .HasForeignKey(tdg => tdg.PriorityId)
                .IsRequired(false);
        }
    }
}
