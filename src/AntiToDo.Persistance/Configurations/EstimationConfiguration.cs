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
            builder.HasQueryFilter(es => !es.IsDeleted);
            builder.HasKey(es => es.Id);
            builder.Property(es => es.Name)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(es => es.Description)
                .HasMaxLength(255)
                .IsRequired(false);
            builder.HasOne(es => es.ToDoItem)
                .WithOne(tdi => tdi.Estimation)
                .IsRequired(false);
            builder.HasOne(es => es.ToDoGroup)
                .WithOne(tdi => tdi.Estimation)
                .IsRequired(false);
        }
    }
}
