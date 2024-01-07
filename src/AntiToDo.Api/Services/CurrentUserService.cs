using AntiToDo.Application.Common.Common.Exceptions;
using AntiToDo.Application.Common.DTOs;
using AntiToDo.Application.Common.Interfaces;
using AntiToDo.Application.Features.Users.Queries;
using AntiToDo.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AntiToDo.Api.Services
{
    /// <summary>
    /// Logged-in user service
    /// </summary>
    public class CurrentUserService : ICurrentUserService
    {
        private UserDto _currentUser;
        private readonly IMediator _mediator;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="httpContextAccessor"></param>
        /// <param name="mediator"></param>
        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IMediator mediator)
        {
            _mediator = mediator;
            Email = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            IsAuthenticated = Email != null;
        }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; }
        /// <summary>
        /// Roles
        /// </summary>
        public List<string> Roles { get; }
        /// <summary>
        /// User Id
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Is authenticated
        /// </summary>
        public bool IsAuthenticated { get; }

        /// <summary>
        /// Retrieves user profile from the database
        /// </summary>
        /// <returns></returns>
        public async Task<UserDto> GetCurrentUserAsync()
        {
            if (_currentUser == null && IsAuthenticated)
            {
                try
                {
                    _currentUser = await _mediator.Send(new GetUserByEmailQuery
                    {
                        Email = Email,
                        IncludeRoles = true
                    });
                }
                catch (NotFoundException)
                {
                    // ignore exception if user wasn't found, in that case it would be null
                }
            }

            return _currentUser;
        }
    }
}
