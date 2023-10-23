using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using AntiTask.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiTask.Persistance.Configurations
{
    public class TaskConfiguration : AuditableEntityConfiguration<Domain.Task>
    {
        public override void ConfigureAuditableEntity(EntityTypeBuilder<Domain.Task> builder)
        {
            builder.HasQueryFilter(task => !task.IsDeleted);
            builder.HasKey(task => task.Id);
            builder.Property(task => task.Name)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(task => task.Description)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(task => task.Priority)
                .HasMaxLength(255)
                .IsRequired();
            builder.HasOne(taskNode => taskNode.Ancestor)
                .WithOne(taskNode => taskNode.Descendant)
                .HasForeignKey("DescendantId");
            builder.HasMany(taskNode => taskNode.Descendants)
                   .WithOne(taskNode => taskNode.Ancestor)
                   .HasForeignKey("AncestorId");
        }
    }
}
