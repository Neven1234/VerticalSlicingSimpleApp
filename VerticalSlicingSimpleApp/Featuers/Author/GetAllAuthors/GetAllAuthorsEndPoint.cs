using Azure;
using Azure.Core;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VerticalSlicingSimpleApp.Common;
using VerticalSlicingSimpleApp.Common.Enums;
using VerticalSlicingSimpleApp.Featuers.Author.GetAllAuthors.Queries;

namespace VerticalSlicingSimpleApp.Featuers.Author.GetAllAuthors
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetAllAuthorsEndPoint : EndPointBase<GetAllAuthorsRequestViewModel,GetAllAuthorResonseViewModel>
    {
      

        public GetAllAuthorsEndPoint(EndPointBaseParameters<GetAllAuthorsRequestViewModel> parameters):base(parameters) 
        {
            
        }
        [HttpGet("GetAll")]
        public async Task<EndPointResonseBase<GetAllAuthorResonseViewModel>> GetAllAuthors([FromQuery] GetAllAuthorsRequestViewModel request)
        {
            var validationResult = ValidateRequest(request);
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }
            var result = await _mediator.Send(new GetAllAuthorQuery(request.PageNumber, request.PageSize, request.SearchTerm, request.IsActive));

            if (result.IsSuccess)
                return EndPointResonseBase<GetAllAuthorResonseViewModel>.Success(result.Data, "Organizations retrieved successfully");

            return EndPointResonseBase<GetAllAuthorResonseViewModel>.Failure(result.ErrorCode);
        }
    }
}
