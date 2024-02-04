using FluentValidation;

namespace grpc.test.pro.Validator
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name).NotEmpty().MinimumLength(4).WithMessage("You must to add at least 4 letters.");
        }
    }
}
