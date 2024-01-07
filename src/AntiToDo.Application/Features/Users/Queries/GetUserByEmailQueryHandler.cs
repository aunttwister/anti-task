using AntiToDo.Application.Common.Common.Exceptions;
using AntiToDo.Application.Common.DTOs;
using AntiToDo.Application.Common.Extensions.DbExtensions;
using AntiToDo.Application.Common.Interfaces.IDbContexts;
using AntiToDo.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Application.Features.Users.Queries
{
    internal class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDto>
    {
        private readonly IAntiToDoDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserByEmailQueryHandler(IAntiToDoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.GetUserByEmailAsync(
                email: request.Email,
                cancellationToken: cancellationToken
            );

            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.Email);
            }

            return _mapper.Map<UserDto>(user);
        }
    }
}
