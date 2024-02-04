using FluentValidation;

namespace grpc.test.pro.Validator
{
    public class PageValidator:AbstractValidator<Page>
    {

        public PageValidator()
        {
            RuleFor(page => page.Page_).GreaterThan(0).WithMessage("You must to add positive number.");
        }
    }
}
