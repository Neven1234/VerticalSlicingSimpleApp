using MediatR;
using VerticalSlicingSimpleApp.Common;
using VerticalSlicingSimpleApp.Common.Enums;
using VerticalSlicingSimpleApp.Featuers.Author.CreateAuthor.Queries;
using VerticalSlicingSimpleApp.Featuers.Author.Dtos;

namespace VerticalSlicingSimpleApp.Featuers.Author.CreateAuthor.Commands
{
    public record CreateAuthoreOrchestrator(string Name):IRequest<RequestResult<CreateAuthorResponseViewModel>>;

    public class CreateAuthoreOrchestratorHandler : RequestHandlerBase<CreateAuthoreOrchestrator, RequestResult<CreateAuthorResponseViewModel>>
    {
        public CreateAuthoreOrchestratorHandler(RequestHandlerBaseParameters parameters) : base(parameters)
        {
        }

        public override async Task<RequestResult<CreateAuthorResponseViewModel>> Handle(CreateAuthoreOrchestrator request, CancellationToken cancellationToken)
        {
            var validationResult = await ValidateRequest(request);
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }
            var newAuthore = await _mediator.Send(new CreateAuthorCommand(request.Name));

            return RequestResult<CreateAuthorResponseViewModel>.Success(
                new CreateAuthorResponseViewModel
                {
                    Author = newAuthore,
                }
                );
        }

        private async Task<RequestResult<CreateAuthorResponseViewModel>> ValidateRequest(CreateAuthoreOrchestrator request)
        {
            var nameExist = await _mediator.Send(new CheckAuthorNameExistQuery(request.Name));
            if (nameExist)
                return RequestResult<CreateAuthorResponseViewModel>.Failure("Author name already exist", ErrorCode.AuthorNameExist);

            return RequestResult<CreateAuthorResponseViewModel>.Success(
                new CreateAuthorResponseViewModel(), "Validation passed");
        }
    }
}
