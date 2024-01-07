using AntiToDo.Application.Common.Authorization;
using AntiToDo.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Application.Features.ToDoItems.CRUD.Commands.CreateToDoItem
{
    public class CreateToDoItemCommandAuthorizer : IRequestAuthorizer<CreateToDoItemCommand>
    {
        private readonly ICurrentUserService _currentUserService;
        public CreateToDoItemCommandAuthorizer(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        public async Task<AuthorizationResult> EvaluateAuthorizationAsync(CreateToDoItemCommand request, CancellationToken cancellationToken = default)
        {
            var user = await _currentUserService.GetCurrentUserAsync();

            if (user != null && user.Role == "Admin")
            {
                return new AuthorizationResult(true);
            }

            return new AuthorizationResult(
                success: false,
                errors: new List<string> { "User is not authorized to update reservations." }
            );
        }
    }
}
