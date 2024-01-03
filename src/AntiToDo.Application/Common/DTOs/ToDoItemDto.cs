using AntiToDo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Application.Common.DTOs
{
    public class ToDoItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public Estimation Estimation { get; set; }
        public DateTime Deadline { get; set; }
    }
}
