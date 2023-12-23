using System.Threading;
using System.Threading.Tasks;

namespace AntiToDo.Application.Common.Authorization
{
    public interface IRequestAuthorizer<TRequest> where TRequest : notnull
    {
        Task<AuthorizationResult> EvaluateAuthorizationAsync(TRequest request, CancellationToken cancellationToken = default);
    }
}
