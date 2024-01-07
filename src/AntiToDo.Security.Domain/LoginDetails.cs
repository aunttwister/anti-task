using AntiToDo.Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Security.Domain
{
    public class LoginDetails : AuditableEntity
    {
        public LoginDetails()
        {
            Roles = new HashSet<Role>();
        }
        public long Id { get; set; }
        public string Email { get; set; }
        public byte[] HashPassword { get; set; }
        public byte[] Salt { get; set; }
        public Guid UserId { get; set; }
        public int RoleId { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}
