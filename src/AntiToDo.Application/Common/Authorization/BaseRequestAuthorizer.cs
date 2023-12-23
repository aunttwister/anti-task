using System.Threading;
using System.Threading.Tasks;

namespace AntiToDo.Application.Common.Authorization
{
    public class BaseRequestAuthorizer<TRequest> : IRequestAuthorizer<TRequest> where TRequest : notnull
    {
        public Task<AuthorizationResult> EvaluateAuthorizationAsync(TRequest request, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new AuthorizationResult(true));
        }
    }
}
