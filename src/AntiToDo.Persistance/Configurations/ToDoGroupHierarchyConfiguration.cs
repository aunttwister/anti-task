using AntiToDo.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Persistance.Configurations
{
    public class ToDoGroupHierarchyConfiguration : IEntityTypeConfiguration<ToDoGroupHierarchy>
    {
        public void Configure(EntityTypeBuilder<ToDoGroupHierarchy> builder)
        {
            builder
                .HasKey(tdgh => new { tdgh.AncestorId, tdgh.DescendantId });
            builder.Property(tdgh => tdgh.Distance)
                .IsRequired(false);

            builder
                .HasOne(tdgh => tdgh.Ancestor)
                .WithMany()
                .HasForeignKey(tdgh => tdgh.AncestorId);

            builder
                .HasOne(tdgh => tdgh.Descendant)
                .WithMany()
                .HasForeignKey(tdgh => tdgh.DescendantId);

        }
    }
}
