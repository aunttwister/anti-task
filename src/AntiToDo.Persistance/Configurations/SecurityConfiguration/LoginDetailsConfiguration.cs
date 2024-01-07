using AntiToDo.Security.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Persistance.Configurations.SecurityConfiguration
{
    public class LoginDetailsConfiguration : AuditableEntityConfiguration<LoginDetails>
    {
        public override void ConfigureAuditableEntity(EntityTypeBuilder<LoginDetails> builder)
        {
            builder.HasQueryFilter(logdet => !logdet.IsDeleted);
            builder.HasKey(logdet => logdet.Id);
            builder.Property(logdet => logdet.HashPassword)
                .HasMaxLength(20)
                .HasColumnType("binary(20)")
                .IsRequired();
            builder.Property(logdet => logdet.Salt)
                .HasMaxLength(16)
                .HasColumnType("binary(16)")
                .IsRequired();
            builder.HasMany(logdet => logdet.Roles)
                .WithMany(rol => rol.LoginDetails);
        }
    }
}
