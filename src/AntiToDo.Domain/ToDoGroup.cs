using AntiToDo.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Domain
{
    public class ToDoGroup : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long PriorityId { get; set; }
        public Priority Priority { get; set; }
        public long EstimationId { get; set; }
        public Estimation Estimation { get; set;}
    }
}
