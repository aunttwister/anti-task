using AntiToDo.Domain;
using AntiToDo.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Persistance.Configurations
{
    public class ReminderConfiguration : AuditableEntityConfiguration<Reminder>
    {
        public override void ConfigureAuditableEntity(EntityTypeBuilder<Reminder> builder)
        {
            builder.HasQueryFilter(rem => !rem.IsDeleted);
            builder.HasKey(rem => rem.Id);
            builder.Property(rem => rem.Name)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(rem => rem.Description)
                .HasMaxLength(255)
                .IsRequired(false);
            builder.Property(rem => rem.StartTime)
                .IsRequired();
            builder.Property(rem => rem.EndTime)
                .IsRequired(false);
            builder.Property(rem => rem.EmailList)
                .IsRequired();
            builder.Property(rem => rem.PhoneNumberList)
                .IsRequired();
            builder.Property(rem => rem.Frequency)
                .HasColumnType($"enum('{ReminderFrequency.Horly}', '{ReminderFrequency.Daily}', '{ReminderFrequency.Weekly}', '{ReminderFrequency.Monthly}')")
                .IsRequired();
        }
    }
}
