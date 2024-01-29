using DataAccess.Data.Entities;
using FluentValidation;

namespace BusinessLogic.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .Matches(@"[A-Z].*").WithMessage("{PropertyName} must starts with uppercase letter.");
        }
    }
}
