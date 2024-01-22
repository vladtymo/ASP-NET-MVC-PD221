using FluentValidation;
using MVC_pd221.Data.Entities;

namespace MVC_pd221.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Price)
                .NotEmpty()
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Description)
                .Length(10, 4000);

            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(2)
                .Matches(@"[A-Z].*").WithMessage("{PropertyName} must starts with uppercase letter.");

            RuleFor(x => x.Category)
                .NotEmpty()
                .MinimumLength(2)
                .Matches(@"[A-Z].*").WithMessage("{PropertyName} must starts with uppercase letter.");
        }
    }
}
