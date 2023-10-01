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
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public EstimationUnit EstimationUnit { get; set; }
    }
}
