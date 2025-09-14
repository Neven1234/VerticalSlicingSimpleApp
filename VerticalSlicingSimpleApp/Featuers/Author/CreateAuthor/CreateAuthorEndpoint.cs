using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VerticalSlicingSimpleApp.Common;
using VerticalSlicingSimpleApp.Featuers.Author.CreateAuthor.Commands;

namespace VerticalSlicingSimpleApp.Featuers.Author.CreateAuthor
{

    public class CreateAuthorEndpoint : EndPointBase<CreateAuthorRequestViewModel, CreateAuthorResponseViewModel>
    {
        public CreateAuthorEndpoint(EndPointBaseParameters<CreateAuthorRequestViewModel> dependencyCollection) : base(dependencyCollection)
        {
        }
        [HttpPost ("CreateAuthor")]
        public async Task <EndPointResonseBase<CreateAuthorResponseViewModel>> CreateAuthor(CreateAuthorRequestViewModel request)
        {
            var result = await _mediator.Send(new CreateAuthoreOrchestrator(request.Name));
            if (result.IsSuccess)
                return EndPointResonseBase<CreateAuthorResponseViewModel>.Success(result.Data, "Authior created Successfully");
            return EndPointResonseBase<CreateAuthorResponseViewModel>.Failure(result.ErrorCode);
        }
    }
}
