using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Security.Common.Interfaces
{
    public interface ITokenProviderService
    {
        public ClaimsPrincipal ExtractClaims(string token);
        public string GenerateRefreshToken(string userId);
        object GenerateToken(string userEmail, IEnumerable<string> roles, string userId);
    }
}
