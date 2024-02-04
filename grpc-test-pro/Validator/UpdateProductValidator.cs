using FluentValidation;

namespace grpc.test.pro.Validator
{
    public class UpdateProductValidator:AbstractValidator<ProductUpdate>
    {
        public UpdateProductValidator()
        {
            RuleFor(product => product.Product.Name).NotEmpty().MinimumLength(4).WithMessage("You must to add at least 4 letters.");
            RuleFor(product => product.Id.Id_).GreaterThan(0).WithMessage("You must to add positive number.");
        }
    }
}
