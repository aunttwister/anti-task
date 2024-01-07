using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Destructurama.Attributed;
using AntiToDo.Application.Common.DTOs;

namespace AntiToDo.Application.Features.Users.Queries
{
    public class GetUserByEmailQuery : IRequest<UserDto>
    {
        /// <summary>
        /// User's email address (mandatory)
        /// </summary>
        [LogMasked(PreserveLength = true)]
        public string Email { get; set; }
        /// <summary>
        /// Flag to include user's roles (default false)
        /// </summary>
        public bool IncludeRoles { get; set; }
    }
}
