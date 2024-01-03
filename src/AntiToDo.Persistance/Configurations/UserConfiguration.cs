using AntiToDo.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Persistance.Configurations
{
    public class UserConfiguration : AuditableEntityConfiguration<User>
    {
        public override void ConfigureAuditableEntity(EntityTypeBuilder<User> builder)
        {
            builder.HasQueryFilter(usr => !usr.IsDeleted);
            builder.HasKey(usr => usr.Id);
            builder.Property(usr => usr.FirstName)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(usr => usr.LastName)
                .HasMaxLength(255)
                .IsRequired(false);
            builder.Property(usr => usr.Email)
                .IsRequired();
            builder.Property(usr => usr.PhoneNumber)
                .IsRequired(false);
        }
    }
}
