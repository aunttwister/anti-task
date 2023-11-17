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
            builder.HasMany(task => task.Ancestors)
                .WithOne(taskNode => taskNode.Descendant)
                .HasForeignKey(taskNode => new { taskNode.AncestorId, taskNode.DescendantId});
            builder.HasMany(task => task.Descendants)
                   .WithOne(taskNode => taskNode.Ancestor)
                   .HasForeignKey(taskNode => new { taskNode.AncestorId, taskNode.DescendantId });
        }
    }
}
