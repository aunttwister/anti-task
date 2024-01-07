using AntiToDo.Security.Common.Interfaces;
using AntiToDo.Security.Features.Authentication.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Security.Features.Audit.Commands
{
    public class CreateAuthenticationAuditCommandHandler : IRequestHandler<CreateAuthenticationAuditCommand, object>
    {
        private readonly ISecurityDbContext _dbContext;
        public CreateAuthenticationAuditCommandHandler(ISecurityDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<object> Handle(CreateAuthenticationAuditCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
