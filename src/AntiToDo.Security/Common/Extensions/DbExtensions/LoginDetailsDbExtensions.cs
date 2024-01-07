using AntiToDo.Domain;
using AntiToDo.Security.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiToDo.Security.Common.Extensions.DbExtensions
{
    public static class LoginDetailsDbExtensions
    {
        public static async Task<LoginDetails> GetLoginDetailsByEmailAsync(
            this DbSet<LoginDetails> loginDetails, string email, bool includeRoles = false, CancellationToken cancellationToken = default)
        {
            IQueryable<LoginDetails> loginDetailsQuery = loginDetails.AsQueryable();

            if (includeRoles)
            {
                loginDetailsQuery = loginDetails.Include(logdet => logdet.Roles);
            }

            return await loginDetailsQuery
                .FirstOrDefaultAsync(logdet => logdet.Email == email, cancellationToken);
        }
    }
}
