using FluentValidation;

namespace grpc.test.pro.Validator
{
    public class IdValidator:AbstractValidator<Id>
    {
        public IdValidator()
        {
            RuleFor(id => id.Id_).GreaterThan(0).WithMessage("You must to add positive number.");
        }
    }
}
