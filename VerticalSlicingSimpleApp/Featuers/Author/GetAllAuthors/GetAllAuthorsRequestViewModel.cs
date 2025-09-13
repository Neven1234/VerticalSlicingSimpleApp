using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VerticalSlicingSimpleApp.Featuers.Author.GetAllAuthors
{
    public record GetAllAuthorsRequestViewModel
    (
        int PageNumber = 1,
        int PageSize = 10,
        string? SearchTerm = null,
        bool? IsActive = null
    );
    public class GetAllAuthorsRequestViewModelValidator : AbstractValidator<GetAllAuthorsRequestViewModel>
    {
        public GetAllAuthorsRequestViewModelValidator()
        {
            RuleFor(request => request.PageNumber)
                .GreaterThan(0)
                .WithMessage("Page number must be greater than 0");
            RuleFor(request => request.PageSize)
                .GreaterThan(0)
                .WithMessage("Page number must be greater than 0")
                .LessThanOrEqualTo(100)
                .WithMessage("Page size cannot exceed 100");
           
        }
    }
}
