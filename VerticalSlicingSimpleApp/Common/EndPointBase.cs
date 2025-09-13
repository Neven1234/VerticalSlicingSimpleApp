using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VerticalSlicingSimpleApp.Common
{
    public class EndPointBase<TRequest, TResult> : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IValidator<TRequest> _validator;
        public EndPointBase(EndPointBaseParameters<TRequest> dependencyCollection)
        {
            _mediator= dependencyCollection.Mediator;
            _validator= dependencyCollection.Validator;
        }
        protected EndPointResonseBase<TResult> ValidateRequest(TRequest request)
        {
            var validateResult = _validator.Validate(request);
            if (!validateResult.IsValid)
            {
                var errorMessage = string.Join(", ", validateResult.Errors.Select(e => e.ErrorMessage));
                return EndPointResonseBase<TResult>.Failure(errorMessage);
            }
            return EndPointResonseBase<TResult>.Success(default, "Validation successful");
        }
    }
}
