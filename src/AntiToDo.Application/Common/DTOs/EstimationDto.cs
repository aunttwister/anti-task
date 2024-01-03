using AntiToDo.Domain.Enum;
using AntiToDo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Application.Common.DTOs
{
    public class EstimationDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Value { get; set; }
        public EstimationUnit EsimationUnit { get; set; }
        public string Description { get; set; }
        public ToDoItemDto ToDoItem { get; set; }
        public ToDoGroupDto ToDoGroup { get; set; }
        public User User { get; set; }
    }
}
