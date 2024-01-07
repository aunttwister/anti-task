using AntiToDo.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Security.Domain
{
    public class Role : AuditableEntity
    {
        public Role()
        {
            LoginDetails = new HashSet<LoginDetails>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<LoginDetails> LoginDetails { get; set; }
    }
}
