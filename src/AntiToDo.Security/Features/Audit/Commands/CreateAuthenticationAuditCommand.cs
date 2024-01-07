using AntiToDo.Security.Common.Helpers.AuthenticationAudit;
using AntiToDo.Security.Common.Helpers.AuthenticationAudit.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Security.Features.Audit.Commands
{
    public class CreateAuthenticationAuditCommand : IRequest<object>
    {
        public string Message { get; set; }
        public string Email { get; set; }
        public DateTime Timestamp { get; set; }
        public int? TokenExpiration { get; set; }

        public static CreateAuthenticationAuditCommand Create(AuthenticationAuditEnum enumValue, string attemptEmail, int? tokenExpiration)
        {
            return new CreateAuthenticationAuditCommand()
            {
                Message = enumValue.ReturnAuditMessage(),
                Email = attemptEmail,
                Timestamp = DateTime.Now,
                TokenExpiration = tokenExpiration
            };
        }
    }
}
