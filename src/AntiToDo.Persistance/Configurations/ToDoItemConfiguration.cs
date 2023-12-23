using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using AntiToDo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.X86;

namespace AntiToDo.Persistance.Configurations
{
    public class ToDoItemConfiguration : AuditableEntityConfiguration<ToDoItem>
    {
        public override void ConfigureAuditableEntity(EntityTypeBuilder<ToDoItem> builder)
        {
            builder.HasQueryFilter(tdi => !tdi.IsDeleted);
            builder.HasKey(tdi => tdi.Id);
            builder.Property(tdi => tdi.Name)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(tdi => tdi.Description)
                .HasMaxLength(255)
                .IsRequired(false);
            builder.HasOne(tdi => tdi.Priority)
                .WithMany(p => p.ToDoItems)
                .HasForeignKey(tdi => tdi.PriorityId)
                .IsRequired(false);
            builder.HasOne(tdi => tdi.Estimation)
                .WithOne(es => es.ToDoItem)
                .HasForeignKey<ToDoItem>(tdi => tdi.EstimationId)
                .IsRequired(false);
        }
    }
}
