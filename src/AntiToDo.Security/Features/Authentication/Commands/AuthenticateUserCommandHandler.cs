using AntiToDo.Application.Common.Common.Exceptions;
using AntiToDo.Application.Common.Exceptions;
using AntiToDo.Security.Domain;
using AntiToDo.Security.Common.Extensions.ObjectExtensions;
using AntiToDo.Security.Common.Helpers.AuthenticationAudit.Enum;
using AntiToDo.Security.Common.Interfaces;
using AntiToDo.Security.Features.Audit.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Security.Features.Authentication.Commands
{
    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, object>
    {
        private readonly ISecurityDbContext _dbContext;
        private readonly IPasswordGeneratorService _authenticationService;
        private readonly ITokenProviderService _tokenProviderService;
        private readonly IMediator _mediator;
        public AuthenticateUserCommandHandler(
            ISecurityDbContext dbContext,
            IPasswordGeneratorService authenticationService,
            ITokenProviderService tokenProviderService,
            IMediator mediator)
        {
            _dbContext = dbContext;
            _authenticationService = authenticationService;
            _tokenProviderService = tokenProviderService;
            _mediator = mediator;
        }

        public async Task<object> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            LoginDetails loginDetails = await _dbContext.LoginDetails.Include(logdet => logdet.Roles).FirstOrDefaultAsync(logdet => logdet.Email == request.Email);

            if (loginDetails == null)
                throw new NotFoundException(nameof(LoginDetails), request.Email);

            bool verifyResponse = _authenticationService.CompareHash(request.Password, loginDetails.Salt, loginDetails.HashPassword);
            CreateAuthenticationAuditCommand auditRequest = null;
            if (!verifyResponse)
            {
                auditRequest = CreateAuthenticationAuditCommand.Create(AuthenticationAuditEnum.AuthenticationFailed, request.Email, null);
                await _mediator.Send(auditRequest);
                throw new UnauthorizedException("User is not authorized."); 
            }

            string userId = loginDetails.UserId.ToString();
            IEnumerable<string> roles = loginDetails.Roles.Select(role => role.Name);

            object token = _tokenProviderService.GenerateToken(loginDetails.Email, roles, userId);

            int expiresIn = (int)token.GetPropertyValue("expires_in");

            auditRequest = CreateAuthenticationAuditCommand.Create(AuthenticationAuditEnum.AuthenticationSuccessful, request.Email, expiresIn);

            await _mediator.Send(auditRequest);

            return token;
        }
    }
}
