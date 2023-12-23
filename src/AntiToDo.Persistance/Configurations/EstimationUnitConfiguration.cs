using AntiToDo.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Persistance.Configurations
{
    public class EstimationConfiguration : AuditableEntityConfiguration<Estimation>
    {
        public override void ConfigureAuditableEntity(EntityTypeBuilder<Estimation> builder)
        {
            builder.HasQueryFilter(e => !e.IsDeleted);
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(e => e.Description)
                .HasMaxLength(255)
                .IsRequired(false);
            builder.HasOne(e => e.ToDoItem)
                .WithOne(tdi => tdi.Estimation)
                .IsRequired(false);
            builder.HasOne(e => e.ToDoGroup)
                .WithOne(tdi => tdi.Estimation)
                .IsRequired(false);
        }
    }
}
