using AntiToDo.Application.Common.DTOs;
using AntiToDo.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Application.Features.ToDoItems.CRUD.Commands.CreateToDoItem
{
    public class CreateToDoItemCommand : IRequest<ToDoItemDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long PriorityId { get; set; }
        public PriorityDto Priority { get; set; }
        public long EstimationId { get; set; }
        public EstimationDto Estimation { get; set; }
        public DateTime Deadline { get; set; }
    }
}
