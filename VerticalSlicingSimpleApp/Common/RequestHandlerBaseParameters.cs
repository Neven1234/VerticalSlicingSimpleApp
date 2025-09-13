using FluentValidation;
using MediatR;

namespace VerticalSlicingSimpleApp.Common
{
    public class RequestHandlerBaseParameters
    {
        private readonly IMediator _mediator;

        public IMediator Mediator => _mediator;


        public RequestHandlerBaseParameters(IMediator mediator)
        {
            this._mediator = mediator;

        }
    }
}
