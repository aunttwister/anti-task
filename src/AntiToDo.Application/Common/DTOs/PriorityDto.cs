using AntiToDo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Application.Common.DTOs
{
    public class PriorityDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public IEnumerable<ToDoItemDto> ToDoItems { get; set; }
        public IEnumerable<ToDoGroupDto> ToDoGroups { get; set; }
        public UserDto User { get; set; }
    }
}
