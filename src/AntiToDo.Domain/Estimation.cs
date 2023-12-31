﻿using AntiToDo.Common.Base;
using AntiToDo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Domain
{
    public class Estimation : AuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Value { get; set; }
        public EstimationUnit EsimationUnit { get; set; }
        public string Description { get; set; }
        public Guid ToDoItemId { get; set; }
        public ToDoItem ToDoItem { get; set; }
        public Guid ToDoGroupId { get; set; }
        public ToDoGroup ToDoGroup { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
