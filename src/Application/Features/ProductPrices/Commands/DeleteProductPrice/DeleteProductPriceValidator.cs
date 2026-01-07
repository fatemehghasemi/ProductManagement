using FluentValidation;

namespace Application.Features.ProductPrices.Commands.DeleteProductPrice;

public sealed class DeleteProductPriceValidator : AbstractValidator<DeleteProductPriceCommand>
{
    public DeleteProductPriceValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Product Price ID must be greater than 0");
    }
}