using AntiToDo.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Persistance.Configurations
{
    public class ToDoGroupConfiguration : AuditableEntityConfiguration<ToDoGroup>
    {
        public override void ConfigureAuditableEntity(EntityTypeBuilder<ToDoGroup> builder)
        {
            builder.HasQueryFilter(tdg => !tdg.IsDeleted);
            builder.HasKey(tdg => tdg.Id);
            builder.Property(tdg => tdg.Name)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(tdg => tdg.Description)
                .HasMaxLength(255)
                .IsRequired(false);
            builder.HasOne(tdg => tdg.Priority)
                .WithMany(p => p.ToDoGroups)
                .HasForeignKey(tdg => tdg.PriorityId)
                .IsRequired(false);
            builder.HasOne(tdg => tdg.Estimation)
                .WithOne(es => es.ToDoGroup)
                .HasForeignKey<ToDoGroup>(tdg => tdg.EstimationId)
                .IsRequired(false);
        }
    }
}
