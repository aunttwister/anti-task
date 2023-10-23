using AntiTask.Domain.Base;
using AntiTask.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiTask.Domain
{
    public class Task : AuditableEntity
    {
        public Task()
        {
            Descendants = new HashSet<TaskNode>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public ICollection<TaskNode> Descendants { get; set; }
        public TaskNode Ancestor { get; set; }

    }
}
