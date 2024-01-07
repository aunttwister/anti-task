using AntiToDo.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Domain
{
    public class ToDoGroupHierarchy : AuditableEntity
    {
        public Guid AncestorId { get; set; }
        public Guid DescendantId { get; set; }
        public long? Distance { get; set; }

        public ToDoGroup Ancestor { get; set; }
        public ToDoGroup Descendant { get; set; }
    }
}
