using FluentValidation;

namespace VerticalSlicingSimpleApp.Featuers.Author.CreateAuthor
{
    public record CreateAuthorRequestViewModel
    (
        string Name
    );
    public class CreateAuthorRequestViewModelValidator : AbstractValidator<CreateAuthorRequestViewModel>
    {
        public CreateAuthorRequestViewModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name of the Author is Required");
        }
    }
}
