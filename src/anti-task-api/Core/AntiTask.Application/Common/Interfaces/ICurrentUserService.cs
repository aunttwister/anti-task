using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntiTask.Application.DataTransferObjects;

namespace AntiTask.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string Email { get; }
        bool IsAuthenticated { get; }

        Task<UserDto> GetCurrentUserAsync();
    }
}
