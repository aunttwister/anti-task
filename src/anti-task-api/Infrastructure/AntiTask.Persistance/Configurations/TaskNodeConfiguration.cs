using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using AntiTask.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace AntiTask.Persistance.Configurations
{
    public class TaskNodeConfiguration : IEntityTypeConfiguration<TaskNode>
    {
        public void Configure(EntityTypeBuilder<TaskNode> builder)
        {
            builder.ToTable(typeof(TaskNode).Name);
            builder.HasKey(taskNode => new { taskNode.AncestorId, taskNode.DescendantId });
        }
    }
}
