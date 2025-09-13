using MediatR;

namespace VerticalSlicingSimpleApp.Common
{
    public abstract class RequestHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected readonly IMediator _mediator;
        protected RequestHandlerBase(RequestHandlerBaseParameters parameters)
        {
            _mediator = parameters.Mediator;
        }
        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);

    }
}
