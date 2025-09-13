using FluentValidation;
using MediatR;

namespace VerticalSlicingSimpleApp.Common
{
    public class EndPointBaseParameters<TRequest>
    {
        private readonly IMediator _mediator;
        private readonly IValidator<TRequest> _validator;

        public IMediator Mediator => _mediator;
        public IValidator<TRequest> Validator => _validator;
        public EndPointBaseParameters(IMediator mediator,IValidator<TRequest> validator)
        {
            _validator = validator;
            _mediator = mediator;
        }
    }
}
