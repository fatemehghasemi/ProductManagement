using FluentValidation;

namespace Application.Features.ProductAdtPrices.Commands.CreateProductAdtPrice;

public sealed class CreateProductAdtPriceValidator : AbstractValidator<CreateProductAdtPriceCommand>
{
    public CreateProductAdtPriceValidator()
    {
        RuleFor(x => x.ProductAdtId)
            .GreaterThan(0).WithMessage("Product Adt ID must be greater than 0");

        RuleFor(x => x.ProductPriceId)
            .GreaterThan(0).WithMessage("Product Price ID must be greater than 0");

        RuleFor(x => x.ProductAdtTypeId)
            .GreaterThan(0).WithMessage("Product Adt Type ID must be greater than 0");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}