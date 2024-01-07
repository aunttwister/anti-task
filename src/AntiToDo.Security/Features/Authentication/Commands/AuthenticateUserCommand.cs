using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Security.Features.Authentication.Commands
{
    public class AuthenticateUserCommand : IRequest<object>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
