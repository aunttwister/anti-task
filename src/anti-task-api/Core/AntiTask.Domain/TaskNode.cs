using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiTask.Domain
{
    public class TaskNode
    {
        public Guid AncestorId { get; set; }
        public virtual Task Ancestor { get; set; }
        public Guid DescendantId { get; set; }
        public virtual Task Descendant { get; set; }
    }
}
