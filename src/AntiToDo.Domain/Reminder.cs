using AntiToDo.Domain.Base;
using AntiToDo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Domain
{
    public class Reminder : AuditableEntity
    {
        public Reminder()
        {
            EmailList = new HashSet<string>();
            PhoneNumberList = new HashSet<string>();
            ToDoItems = new HashSet<ToDoItem>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public ICollection<string> EmailList { get; set; }
        public ICollection<string> PhoneNumberList { get; set; }
        public ReminderFrequency Frequency { get; set; }
        public Guid ToDoItemId { get; set; }
        public ICollection<ToDoItem> ToDoItems { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
