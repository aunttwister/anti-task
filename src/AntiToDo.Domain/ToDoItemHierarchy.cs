using AntiToDo.Common.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Domain
{
    public class ToDoItemHierarchy : AuditableEntity
    {
        public Guid AncestorId { get; set; }
        public Guid DescendantId { get; set; }
        public long? Distance { get; set; }

        public ToDoItem Ancestor { get; set; }
        public ToDoItem Descendant { get; set; }
    }
}
