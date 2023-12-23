using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using AntiToDo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Persistance.Configurations
{
    public class ToDoItemHierarchyConfiguration : IEntityTypeConfiguration<ToDoItemHierarchy>
    {
        public void Configure(EntityTypeBuilder<ToDoItemHierarchy> builder)
        {
            builder
                .HasKey(tdih => new { tdih.AncestorId, tdih.DescendantId });
            builder.Property(tdih => tdih.Distance)
                .IsRequired(false);

            builder
                .HasOne(tdih => tdih.Ancestor)
                .WithMany()
                .HasForeignKey(tdih => tdih.AncestorId);

            builder
                .HasOne(tdih => tdih.Descendant)
                .WithMany()
                .HasForeignKey(tdih => tdih.DescendantId);

        }
    }
}
