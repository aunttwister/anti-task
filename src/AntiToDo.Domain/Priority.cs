using AntiToDo.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Domain
{
    public class Priority : AuditableEntity
    {
        public Priority() 
        {
            ToDoItems = new HashSet<ToDoItem>();
            ToDoGroups = new HashSet<ToDoGroup>();
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public ICollection<ToDoItem> ToDoItems { get; set; }
        public ICollection<ToDoGroup> ToDoGroups { get; set; }
    }
}
