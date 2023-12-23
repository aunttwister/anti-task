using AntiToDo.Application.Common.Authorization;
using AntiToDo.Application.Common.Exceptions;
using MediatR;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace AntiToDo.Application.Common.Behaviours
{
    public class RequestAuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IRequestAuthorizer<TRequest> _requestAuthorizer;

        public RequestAuthorizationBehavior(IRequestAuthorizer<TRequest> requestAuthorizer)
        {
            _requestAuthorizer = requestAuthorizer;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var authorizationResult = await _requestAuthorizer.EvaluateAuthorizationAsync(request, cancellationToken);
            if (!authorizationResult.Success)
            {
                throw new UnauthorizedException(JsonSerializer.Serialize(authorizationResult.Errors));
            }

            return await next();
        }
    }
}
