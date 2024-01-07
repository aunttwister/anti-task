using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AntiToDo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntiToDo.Common.Base;

namespace AntiToDo.Persistance.Configurations
{
    public abstract class AuditableEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : AuditableEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(auditableEntity => auditableEntity.CreatedBy)
                .HasMaxLength(128);
            builder.Property(auditableEntity => auditableEntity.LastModifiedBy)
                .HasMaxLength(128);
            builder.Property(auditableEntity => auditableEntity.Created)
                .HasColumnType("datetime")
                .HasDefaultValueSql("now()")
                .IsRequired();
            builder.Property(auditableEntity => auditableEntity.LastModified)
                .HasColumnType("datetime")
                .IsRequired(false);
            builder.Property(auditableEntity => auditableEntity.IsDeleted)
                .HasColumnType("bit")
                .HasDefaultValue(false)
                .IsRequired();
            ConfigureAuditableEntity(builder);
        }

        /// <summary>
        /// Configures model entity
        /// </summary>
        /// <param name="builder"></param>
        public abstract void ConfigureAuditableEntity(EntityTypeBuilder<TEntity> builder);
    }
}
